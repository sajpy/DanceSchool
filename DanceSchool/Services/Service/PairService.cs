using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using DanceSchool.DTO.Pair;
using DanceSchool.Entities;
using DanceSchool.Repositories.Repository;
using DanceSchool.Services.IService;
using DanceSchool.UOW;

namespace DanceSchool.Services.Service
{
    public class PairService : IPairService
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;


        public PairService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pair> AddPairAsync(PairCreateDto pairCreateDto)
        {
            User user1 = await _unitOfWork.UserRepository.GetEntityById(pairCreateDto.User1Id);

            if(pairCreateDto.User2Id != null)
            {
                int user2Id = (int)pairCreateDto.User2Id;
                User user2 = await _unitOfWork.UserRepository.GetEntityById(user2Id);

                Pair pair = new()
                {
                    User1Id = user1.Id,
                    User1 = user1,
                    User2Id = user2.Id,
                    User2 = user2
                };
                Pair pair2 = _mapper.Map<Pair>(pair);
                await _unitOfWork.PairRepository.CreateEntity(pair2);
                await _unitOfWork.CommitAsync();
                return pair2;
            }
            else
            {
                Pair pair = new Pair
                {
                    User1 = user1,
                    User2Id = null,
                    User2 = null
                };
                Pair pair2 = _mapper.Map<Pair>(pair);
                await _unitOfWork.PairRepository.CreateEntity(pair2);
                await _unitOfWork.CommitAsync();
                return pair2;
            }
        }

        public Task DeletePairAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PairDto>> GetAllPairsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PairDto> GetPairByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePairAsync(PairDto pair)
        {
            throw new NotImplementedException();
        }

        public async Task<SelectList> GetUserSelectListAsync()
        {
            List<User> users = await _unitOfWork.UserRepository.GetAllUsersAsync();

            List<SelectListItem> userItems = users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}"
            }).ToList();

            return new SelectList(userItems, "Value", "Text");
        }
    }
}
