using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Computer_Vision
{
    public class ComputerVision
    {
        [JsonProperty(PropertyName = "categories")]
        public Category[] Categories { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty(PropertyName = "description")]
        public Description Description { get; set; }

        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty(PropertyName = "faces")]
        public Face[] Faces { get; set; }

        [JsonProperty(PropertyName = "color")]
        public Color Color { get; set; }

        [JsonProperty(PropertyName = "imageType")]
        public Imagetype ImageType { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }

    public class Description
    {
        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty(PropertyName = "captions")]
        public Caption[] Captions { get; set; }
    }

    public class Caption
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }
    }

    public class Metadata
    {
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }
    }

    public class Color
    {
        [JsonProperty(PropertyName = "dominantColorForeground")]
        public string DominantColorForeground { get; set; }

        [JsonProperty(PropertyName = "dominantColorBackground")]
        public string DominantColorBackground { get; set; }

        [JsonProperty(PropertyName = "dominantColors")]
        public string[] DominantColors { get; set; }

        [JsonProperty(PropertyName = "accentColor")]
        public string AccentColor { get; set; }

        [JsonProperty(PropertyName = "isBWImg")]
        public bool IsBWImg { get; set; }
    }

    public class Imagetype
    {
        [JsonProperty(PropertyName = "clipArtType")]
        public int ClipArtType { get; set; }

        [JsonProperty(PropertyName = "lineDrawingType")]
        public int LineDrawingType { get; set; }
    }

    public class Category
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float Score { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public Detail Detail { get; set; }
    }

    public class Detail
    {
        [JsonProperty(PropertyName = "celebrities")]
        public Celebrity[] Celebrities { get; set; }
    }

    public class Celebrity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "faceRectangle")]
        public Facerectangle FaceRectangle { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }
    }

    public class Facerectangle
    {
        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }

        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }

    public class Tag
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public float Confidence { get; set; }
    }

    public class Face
    {
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "faceRectangle")]
        public Facerectangle1 FaceRectangle { get; set; }
    }

    public class Facerectangle1
    {
        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }

        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }

}
