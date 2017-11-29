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
        public async Task<string> Post<T>(string url, T obj)
        {
            var address = _baseAddress + url;
            var data = Serialize(obj);
            HttpResponseMessage response = await _client.PostAsync(address, data);
            //string 

            //return constructResponse();

            if (response.IsSuccessStatusCode)
            {

            }



            string result = await Deserialize<string>(response);
            return result;

        }

        // Get
        public async Task<T> Get<T>(string url)
        {
            var address = _baseAddress + url;
            var response = await _client.GetAsync(address);
            T result = await Deserialize<T>(response);
            return result;
        }

        // Put
        //public async Task<HttpResponseMessage> Put<T>(string url, T obj)
        //{
        //    var address = _baseAddress + url;
        //    var data = Serialize(obj);
        //    var response = await _client.PutAsync(address, data);
        //    ResponseAPI result = await Deserialize<ResponseAPI>(response);
        //    return result;
        //}

        //// Delete
        //public async Task<HttpResponseMessage> Delete(string url)
        //{
        //    var address = _baseAddress + url;

        //    var response = await _client.DeleteAsync(address);
        //    ResponseAPI result = await Deserialize<R>(response);
        //    return result;
        //}

        // JSON serialize
        StringContent Serialize<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        // JSON deserialize
        async Task<T> Deserialize<T>(object res)
        {

            //if (res is string)
            //{
            //    return JsonConvert.DeserializeObject<T>((string)res);
            //}

            HttpResponseMessage mes = (HttpResponseMessage)res;
            var content = await mes.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }


    }
}
