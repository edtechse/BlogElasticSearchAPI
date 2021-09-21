using System;
using System.Text.Json.Serialization;

namespace BlogElasticSearchService.Model
{
    [Serializable]
    public class Blog
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blogtitle")]
        public string BlogTitle { get; set; }

        [JsonPropertyName("blogtext")]
        public string BlogText { get; set; }

        [JsonPropertyName("blogcreationdate")]
        public string BlogCreationDate { get; set; }

        [JsonPropertyName("blogauthor")]
        public string BlogAuthor { get; set; }

        [JsonPropertyName("likescount.S")]
        public string LikesCount { get; set; }

        [JsonPropertyName("rating.S")]
        public string Rating { get; set; }

        [JsonPropertyName("blogtags.SS")]
        public string BlogTags { get; set; }
    }

    public class Comments
    {
        [JsonPropertyName("commentid")]
        public string CommentId { get; set; }

        [JsonPropertyName("commenttext")]
        public string CommentText { get; set; }

        [JsonPropertyName("commentauthor")]
        public string CommentAuthor { get; set; }

        [JsonPropertyName("commentcreationdate")]
        public string CommentCreationDate { get; set; }
    }
}
