using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model.Entity;
using System.Windows.Input;

namespace Ecommerce.Helper
{
    public class ImageBB
    {
        protected string apiKey;
        public ImageBB()
        {
            apiKey = "af5a7c2303d6312d6bd635bdb1aae90a";
        }
        public async Task<ResponseImageBB> UploadImageAsync(string imagePath, string name = null)
        {
            using (var client = new HttpClient())
            {
                var apiUrl = "https://api.imgbb.com/1/upload";

                var content = new MultipartFormDataContent();

                // Baca gambar dari file
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Tambahkan file sebagai bagian dari permintaan
                content.Add(new ByteArrayContent(imageBytes), "image", "image.png");

                // Tambahkan parameter expiration ke URL
                var expiration = 600; // Ganti dengan nilai expiration yang diinginkan
                /*apiUrl += $"?expiration={expiration}&key={apiKey}";*/
                apiUrl += $"?key={apiKey}";

                // Atur header Authorization pada DefaultRequestHeaders
                // client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {apiKey}");

                // Kirim permintaan
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Cek response
                if (response.IsSuccessStatusCode)
                {
                    // Dapatkan hasil response
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse hasil response
                    var responseJson = JsonConvert.DeserializeObject<ResponseImageBB>(responseBody);

                    // Kembalikan hasil response
                    return responseJson;
                }
                else
                {
                    // Kembalikan error
                    return null;
                }
            }
        }

    }
}
