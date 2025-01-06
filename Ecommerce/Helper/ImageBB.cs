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
using System.Net;
using System.Windows.Forms;
using System.Drawing;

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

                byte[] imageBytes = File.ReadAllBytes(imagePath);

                content.Add(new ByteArrayContent(imageBytes), "image", "image.png");

                var expiration = 600; 
                apiUrl += $"?key={apiKey}";

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject<ResponseImageBB>(responseBody);
                    return responseJson;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void DownloadAndSetImage(string imageUrl, PictureBox pictureBox)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);

                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(stream);
                        pictureBox.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
