﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }
        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri ="https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),Encoding.UTF8,"application/json");
            var response = await _apiClient.PostAsync(uri,transferContent);

            response.EnsureSuccessStatusCode();
           
             
        }
    }
}
