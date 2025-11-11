using AutoMapper;
using PRM392_API.DTOs.FCMToken;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PRM392_API.Services.Implementation
{
    public class FCMTokenService : IFCMTokenService
    {
        private readonly IFCMTokenRepository _fcmTokenRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient = new HttpClient();
        
        public FCMTokenService(IFCMTokenRepository fcmTokenRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _fcmTokenRepository = fcmTokenRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FCMToken>> GetTokensByUserIdAsync(int[] userId)
        {
           return await _fcmTokenRepository.GetTokensByUserIdAsync(userId);
        }


public async Task<IEnumerable<string>?> GetTokensFromFirebaseAsync(int classId)
    {
        string BaseUrl = $"https://prm392finalproject-5c391-default-rtdb.asia-southeast1.firebasedatabase.app/fcmTokens/{classId}.json";
        try
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json); 

                var resultDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                if (resultDictionary != null)
                {
                    return resultDictionary.Values;
                }

                return new List<string>(); 
            }
            return new List<string>();
        }
        catch (Exception ex)
        {
            return new List<string>();
        }
    }

    public async Task SaveTokenAsync(AddFCMTokenRequest addFCMTokenRequest)
        {
           var fcmToken = _mapper.Map<Models.FCMToken>(addFCMTokenRequest);
            await _fcmTokenRepository.AddOrUpdateTokenAsync(fcmToken);
        }

        public async Task<List<int?>> GetClassByUserId(int userId)
        {
            return await _fcmTokenRepository.GetClassByUserId(userId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsNearingDeadline(TimeSpan timeSpan)
        {
            return await _fcmTokenRepository.GetAssignmentsNearingDeadline(timeSpan);
        }

        public async Task<int?> GetGroupIdByStudentIdAndClassId(int studentId, int classId)
        {
            return await _groupRepository.GetGroupIdByStudentIdAsync(studentId, classId);
        }
    }
}
