using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CS_Computer_Vision
{
    class Program
    {
        //computer vision için gerekli olan key ve request'in yapılacağı uriBase
        const string subscriptionKey_Vision = "YOUR KEY";
        const string uriBase_Vision = "https://westeurope.api.cognitive.microsoft.com/vision/v1.0";

        static void Main()
        {

            Console.Write("Enter image URL: ");
            var imageURL = Console.ReadLine();

            //// Computer Vision - Image Tag Örneği
            ComputerVisionRequest(imageURL);

            //Computer Vision Altında OCR Request Örneği
            OCRRequest(imageURL);

            Console.ReadLine();
        }

        static async void ComputerVisionRequest(string imageUrl)
        {
            var client = new HttpClient();

            // Request headers
            // Face, Tags, Categories, ImageType, Color, Celebrity, Landmark detaylarının alınacağı sorgu aşağıdaki gibidir
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey_Vision);
            string uri = uriBase_Vision + "/analyze?visualFeatures=Faces,Tags,categories,Description,ImageType,Color&details=Celebrities,Landmarks";


            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"Url\": \"" + imageUrl + "\"}");
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                //Json Deserialization
                string json = response.Content.ReadAsStringAsync().Result;
                json = json.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                ComputerVision photoVision = JsonConvert.DeserializeObject<ComputerVision>(json);

                List<string> myTags = new List<string>();
                Console.WriteLine("---\n\nCategory Detayları");
                foreach (Category pCategory in photoVision.Categories)
                {
                    Console.WriteLine(pCategory.Name + "-" + pCategory.Score + "-" + pCategory.Detail);
                }

                Console.WriteLine("---\n\nPhoto Tag Detayları");
                foreach (Tag pTag in photoVision.Tags)
                {
                    Console.WriteLine(pTag.Name + "-" + pTag.Confidence);
                    myTags.Add(pTag.Name);
                }

                Console.WriteLine("---\n\nDescription Tag Detayları");
                foreach (string pTag in photoVision.Description.Tags)
                {
                    Console.WriteLine(pTag);
                    myTags.Add(pTag);
                }

                List<string> myDecription = new List<string>();
                foreach (Caption pCaption in photoVision.Description.Captions)
                {
                    Console.WriteLine(pCaption.Text + " - " + pCaption.Confidence);
                    myDecription.Add(pCaption.Text);
                }


                foreach (Face pface in photoVision.Faces)
                {
                    Console.WriteLine("---\n\nDescription Tag Detayları");
                    Console.WriteLine("Age: " + pface.Age);
                    Console.WriteLine("Gender: " + pface.Gender);
                }

                Console.WriteLine("---\n\nColor Tag Detayları");
                Console.WriteLine("dominantColorForeground: " + photoVision.Color.DominantColorForeground);
                Console.WriteLine("dominantColorBackground: " + photoVision.Color.DominantColorBackground);
                Console.WriteLine("accentColor: " + photoVision.Color.AccentColor);
                Console.WriteLine("isBWImg: " + photoVision.Color.IsBWImg);

                Console.WriteLine("---\n\nDominantColors Detayları");
                foreach (string dColors in photoVision.Color.DominantColors)
                {
                    Console.WriteLine(dColors);
                }

            }
        }

        static async void OCRRequest(string imageUrl)
        {

            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey_Vision);
            string uri = uriBase_Vision + "/ocr?language=tr&detectOrientation=true";
            HttpResponseMessage response;

            //Console.Write("Enter image URL: ");
            //var imageUrl = Console.ReadLine();

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"Url\": \"" + imageUrl + "\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                try
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);

                    //JSON Deserialization
                    string json = response.Content.ReadAsStringAsync().Result;
                    json = json.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                    OCRVision ocrVision = JsonConvert.DeserializeObject<OCRVision>(json);

                    Console.WriteLine("---\n\nOCR Detayları");
                    //OCR'dan elde edilen sonuçların ekrana yazılması
                    foreach (Region ereg in ocrVision.Regions)
                    {
                        foreach (Line sline in ereg.Lines)
                        {
                            foreach (Word sword in sline.Words)
                            {
                                Console.Write(sword.Text + "\n");
                            }
                        }
                    }
                }
                catch
                {
                    Console.Write("OCR couldn't find");
                }
            }
        }

    }
}
