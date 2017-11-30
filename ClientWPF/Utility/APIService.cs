using ClientWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Services
{
    public class APIService
    {
        string _baseAddress;
        HttpClient _client;

        public APIService()
        {
            _baseAddress = "http://localhost:1029/api/";
            _client = new HttpClient();
        }

        // Post
        public async Task<Response> Post<T>(string url, T obj)
        {
            var address = _baseAddress + url;

            try
            {
                var data = Serialize(obj);
                HttpResponseMessage response = await _client.PostAsync(address, data);
                Response result = await Deserialize<Response>(response);
                return result;
            }
            catch (HttpRequestException e)
            {
                // log exception (serilog?) 
                throw new Exception("API Connection error");
            }
        }

        // Get
        public async Task<T> Get<T>(string url)
        {
            var address = _baseAddress + url;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(address);
                T result = await Deserialize<T>(response);
                return result;
            }
            catch (HttpRequestException e)
            {
                // log exception (serilog?) 
                throw new Exception("API Connection error");
            }
        }

        // Put
        public async Task<Response> Put<T>(string url, T obj)
        {
            var address = _baseAddress + url;

            try
            {
                var data = Serialize(obj);
                HttpResponseMessage response = await _client.PutAsync(address, data);
                Response result = await Deserialize<Response>(response);
                return result;
            }
            catch (HttpRequestException e)
            {
                // log exception (serilog?) 
                throw new Exception("API Connection error");
            }
        }

        // Delete
        public async Task<Response> Delete(string url)
        {
            var address = _baseAddress + url;

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(address);
                Response result = await Deserialize<Response>(response);
                return result;
            }
            catch (HttpRequestException e)
            {
                // log exception (serilog?) 
                throw new Exception("API Connection error");
            }

        }

        // JSON serialize
        StringContent Serialize<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        // JSON deserialize
        async Task<T> Deserialize<T>(HttpResponseMessage res)
        {
            var content = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
