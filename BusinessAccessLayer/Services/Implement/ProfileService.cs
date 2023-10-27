using AutoMapper;
using BusinessAccessLayer.Services.Interface;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class ProfileService : BaseService<User>, IProfileService
    {
        public readonly IBaseRepository<User> _baseRepository;
        public readonly IAuthenticationRepository _authenticationRepository;
        public new readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public ProfileService(IBaseRepository<User> repo, IUnitOfWork unitOfWork,IMapper mapper, 
            IAuthenticationRepository authenticationRepository) : base(repo, unitOfWork)
        {
            _baseRepository = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationRepository = authenticationRepository;
        }

        public async Task UpdateProfile(UpdateUserDTO userDetails)
        {
            User user=_mapper.Map<User>(userDetails);
            await UpdateAsync(user);
        }

        public async Task ChangePassword(ChangedPasswordDTO passwordDetails)
        {
            //User user = _authenticationRepository.GetUserByEmail();
        }
    }
}
