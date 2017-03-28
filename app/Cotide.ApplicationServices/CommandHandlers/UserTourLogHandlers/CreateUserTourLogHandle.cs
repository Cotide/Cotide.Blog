//-------------------------------------------------------------------
//��Ȩ���У���Ȩ����(C) 2010��Microsoft(China) Co.,LTD
//ϵͳ���ƣ� 
//�ļ����ƣ�CreateUserTourLogHandlers.cs
//ģ�����ƣ�
//ģ���ţ�
//�������ߣ�lhc
//����ʱ�䣺2013/3/9 0:04:03 
//����˵����
//-----------------------------------------------------------------
//�޸ļ�¼�� 
//�޸��ˣ�   
//�޸�ʱ�䣺 
//�޸����ݣ� 
//-----------------------------------------------------------------  

using System;
using System.Linq;
using Cotide.Domain;
using Cotide.Domain.Contracts.Repositories;
using Cotide.Framework.Utility;
using Cotide.Tasks.Commands.UserTourLogCommands;
using SharpArch.Domain.Commands;

namespace Cotide.Tasks.CommandHandlers.UserTourLogHandlers
{
    public class CreateUserTourLogHandle : ICommandHandler<CreateUserTourLogCommand>
    {
        protected IUserTourLogRepository UserTourLogRepository;

        protected IUserRepository UserRepository;
         

        public CreateUserTourLogHandle(IUserTourLogRepository userTourLogRepository,
            IUserRepository userRepository)
        {
            UserTourLogRepository = userTourLogRepository;
            UserRepository = userRepository;
        }

        public void Handle(CreateUserTourLogCommand command)
        { 

            //��ǰ�û��ǵ�ǰ�����û� �����з�����Ϣ��¼
            if(command.UserId==command.TourUserId)
                return;  

            var query = (from utr in UserTourLogRepository.FindAll()
                         let u = utr.User
                         let ut = utr.TourUser
                         where u.Id == command.UserId
                               && ut.Id == command.TourUserId
                         select utr);

            var obj = query.FirstOrDefault();
            if (obj != null)
            {
                // ���и���&����
                obj.LastDateTime = DateTime.Now;
                UserTourLogRepository.Update(obj);
            }
            else
            {

                
                var user = UserRepository.Get(command.UserId);
                Guard.IsNotNull(user,"user");

                var insertTourUser = UserRepository.Get(command.TourUserId);
                Guard.IsNotNull(insertTourUser, "insertTourUser");


                UserTourLogRepository.Save(new UserTourLog()
                {
                    User = user,
                    CreateDate = DateTime.Now,
                    TourUser = insertTourUser,
                     LastDateTime = DateTime.Now
                });

                 
                // ����ɾ��&����
                var maxIndex = GetMaxSort(command.UserId);
                if (command.MaxTourUserCount != null && command.MaxTourUserCount > 0)
                {
                    if (maxIndex > command.MaxTourUserCount)
                    { 
                        var endObj = (from ut in UserTourLogRepository.FindAll()
                                     let u = ut.User
                                     where u.Id == command.UserId 
                                     orderby ut.LastDateTime descending 
                                     select ut).FirstOrDefault();

                        UserTourLogRepository.Delete(endObj);
                    }

                }
            }
        }


        /// <summary>
        /// ��ȡ��ǰ�����û������Sortֵ
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private int GetMaxSort(int userId)
        {
            return (from u in UserRepository.FindAll()
                    let ur = u.UserTourLogs
                    where u.Id == userId
                    select ur).Count(); 
        }

    }
}
