#region using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cotide.Framework.Attr.Desc;
using Cotide.Infrastructure.NHibernateMaps;
using Cotide.Infrastructure.NHibernateMaps.Conventions;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NHibernate.Persister.Entity;
using NHibernate.SqlTypes;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SharpArch.NHibernate;
using Tests.SharpArch.NHibernate;

#endregion

namespace Tests.Cotide.Infrastructure.NHibernateMaps
{
    /// <summary>
    ///     Provides a means to verify that the target database is in compliance with all mappings.
    ///     Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    ///     If this is failing, the error will likely inform you that there is a missing table or column
    ///     which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [Category("DB Schema Tests")]
    public class FluentMappingIntegrationTests
    {
        #region Setup/Teardown

        [SetUp]
        public virtual void SetUp()
        {
            var mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            _nhConfig = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                                               new AutoPersistenceModelGenerator().Generate(),
                                               TEST_DB_CONFIG_PATH);
        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSession.CloseAllSessions();
            NHibernateSession.Reset();
        }

        #endregion

        private static SchemaUpdate PrepareSchemaUpdate()
        {
            return new SchemaUpdate(_nhConfig);
        }

        private static SchemaExport PrepareSchemaExport()
        {
            return new SchemaExport(_nhConfig);
        }

        private const string TEST_DB_CONFIG_PATH = "../../../../tests/Cotide.Tests/Hibernate.cfg.xml";
         

        [Test]
        public void ExportSchemaToFile()
        {
            PrepareSchemaExport().Execute(true, false, false, null, new StreamWriter(DB_FOLDER_PATH + "schema/DbSchema.sql"));
        }

        [Test]
        public void UpdateLiveDbSchema()
        {
            PrepareSchemaUpdate().Execute(true, false);
        }

        [Test]
        public void WriteMappingsToFile()
        {
            var mappings = new AutoPersistenceModelGenerator().Generate();
            mappings.BuildMappings();
            mappings.WriteMappingsTo(DB_FOLDER_PATH + "maps/");
        }

        /// <summary>
        /// �ļ����Ŀ¼
        /// </summary>
        private const string DB_FOLDER_PATH = "../../../../db/";

        /// <summary>
        /// �������DLL��
        /// </summary>
        private const string DomainDll = "Cotide.Domain";

        /// <summary>
        /// NHibernate Configuration
        /// </summary>
        private static NHibernate.Cfg.Configuration _nhConfig;

        [Test]
        public void WriteDomainDbInfo()
        {
            // ��ȡNHibernate ��ȡ����ʵ��Ԫ���ݼ��� 
            // ͨ��NHibernateSession��̬�� -> ��ȡĬ�Ϲ��� -> ��ȡ��������ʵ��Ԫ����
            var allClassMetadata = NHibernateSession.
                GetDefaultSessionFactory().GetAllClassMetadata();

            // ������ݱ���
            var str = new StringBuilder();
            // ����Ԫ����
            foreach (var entry in allClassMetadata)
            {
                // ��ȡ��ǰԪ����
                var entity = ((SingleTableEntityPersister)entry.Value);
                // ��ȡʵ��ӳ��ı���
                var tableName = entity.TableName;
                // ����ʵ������
                var entityName = entity.EntityName; 
                // ����ʵ��Mapping����
                var userClassMap = _nhConfig.GetClassMapping(entityName); 
                // ����ʵ��������
                var primaryKey = userClassMap.Table.PrimaryKey.Columns.FirstOrDefault().Text;
                // ����ʵ���µ������б�
                var column = userClassMap.Table.ColumnIterator;

                // �����ͷ
                str.Append(string.Format("<H1>{0}({1})</H1>", tableName, entityName));

                // ��ȡʵ������
                // ʹ�÷���dll -> ��ȡEntityDescAttribute������������
                var type = Type.GetType(entityName + "," + DomainDll);
                if (type != null)
                {
                    var attr = type.GetCustomAttributes(typeof(EntityDescAttribute), true);
                    if (attr.Length > 0)
                    {
                        str.Append(string.Format("<P>������:{0}</P>",
                            ((EntityDescAttribute)attr[0]).Description));
                    }
                }
                 
                // �������ͷ
                str.Append("<table width=\"100%\" " +
                           "border=\"1\" " + 
                           "cellspacing=\"0\" " +
                           "bordercolor=\"#333\" >");
                str.Append("<tr style='background-color:#3AF;'>" +
                           "<td>���</td>" +
                           "<td>���ݿ��ֶ�</td>" +
                           "<td>����</td>" +
                           "<td>����</td>" +
                           "<td>ΨһԼ��</td>" +
                           "<td>����ΪNULL</td>" +
                           "<td>�Ƿ�����</td>" +
                           "</tr>");
                // ��������ʵ���µ�����
                // ˳������
                var index = 0;
                foreach (var obj in column)
                {
                    // ��������
                    var attrDesc = "";

                    // ��ȡNHibernate Column����
                    var item = (Column)obj.Value.ColumnIterator.FirstOrDefault();
                    if (item == null)
                        continue;

                    // �ж����Ϊ����ʵ��Ψһ��ʶ�򲻻�ȡ��������
                    if (primaryKey == item.Text)
                    {
                        //Ψһ��ʶ
                        attrDesc = "Ψһ��ʶ";
                    } 
                    else
                    {
                        // ������������� -> �ж�Ϊ�����ݿ��ֶ�,Ϊ����ʵ������
                        // -> �������δ���
                        if(index >= entity.PropertyNames.Count())
                        {
                            continue;
                        }

                        // ��ȡ�����ϵ�EntityPropertyDescAttribute������������ 
                        var memberItem = entity.PropertyNames[index];
                        if(type!=null)
                        {
                            var property = type.GetProperty(memberItem);
                            var memberAttr = property.GetCustomAttributes(
                                typeof(EntityPropertyDescAttribute), true);

                            if (memberAttr.Length > 0)
                            {
                                attrDesc = ((EntityPropertyDescAttribute)
                                    memberAttr[0]).Description;
                            } 
                        }
                        ++index;
                    }

                    // �������
                    str.Append(string.Format("<tr>" +
                                             "<td>{0}</td>" +
                                             "<td>{1}</td>" +
                                             "<td>{2}</td>" +
                                             "<td>{3}</td>" +
                                             "<td>{4}</td>" +
                                             "<td>{5}</td>" +
                                             "<td>{6}</td>" +
                                             "</tr>",
                          index + 1,
                          item.Text, GetType(item.Value.Type),
                          attrDesc,
                          item.IsUnique ? "Yes" : "No",
                          item.IsNullable ? "Yes" : "No",
                          (primaryKey == obj.Name) ? "Yes" : "No")); 
                }
                str.Append("</table>");
            }
            // ������ݿ��ֵ��ļ�
            // �ļ���
            const string outputFileName = "���ݿ��ֵ�.doc";
            // ����ļ���·��
            string outputFilePath = Path.Combine(DB_FOLDER_PATH, outputFileName);
            // �������
            File.WriteAllText(outputFilePath, str.ToString(), Encoding.GetEncoding("utf-8"));
        }

        #region Helper 

        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetType(NHibernate.Type.IType type)
        {
            if (type is NHibernate.Type.Int32Type)
            {
                return "int";
            }
            if (type is NHibernate.Type.StringType)
            {
                var sqlType = ((NHibernate.Type.StringType)type).SqlType;
                return string.Format("nvarchar({0})", GetLength(sqlType));
            }
            if (type is NHibernate.Type.BooleanType)
            {
                return "bit";
            }
            if (type is NHibernate.Type.DateTimeType)
            {
                return "datetime";
            }
            if (type is NHibernate.Type.DecimalType)
            {
                return "decimal";
            }
            if (type is NHibernate.Type.DoubleType)
            {
                return "double";
            }
            if (type is NHibernate.Type.Int64Type)
            {
                return "bitint";
            }
            if (type is NHibernate.Type.CharType)
            {
                return "char";
            }
            if (type is NHibernate.Type.TimestampType)
            {
                return "timestamp";
            }
            if (type is NHibernate.Type.Int16Type)
            {
                return "tinyint";
            }
            if (type is NHibernate.Type.XmlDocType)
            {
                return "xml";
            }
            if (type is NHibernate.Type.BinaryType)
            {
                var sqlType = ((NHibernate.Type.StringType)type).SqlType;
                return string.Format("varbinary({0})", sqlType.Length > 4000 ? "max" : sqlType.Length.ToString());
            }

            if (type is NHibernate.Type.PersistentEnumType)
            {
                var enumType = (NHibernate.Type.PersistentEnumType)type;
                return enumType.SqlType.DbType.ToString() == "Int32" ? "int" : "nvarchar(255)";
            }
            if (type is NHibernate.Type.EntityType)
            {
                // ��ʱʹ�����ַ�ʽ,�Ժ��ع�
                return "int";
            }
            return "δ֪";
        }

        /// <summary>
        /// ��ȡSQL����
        /// </summary>
        /// <param name="sqlType">SQL����</param>
        /// <returns></returns>
        private static string GetLength(SqlType sqlType)
        {
            return sqlType.Length > 4000 ? "max" : sqlType.Length <= 0 ? "255" : sqlType.Length.ToString();
        }

        #endregion

    }
}