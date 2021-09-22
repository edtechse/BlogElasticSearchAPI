using BlogElasticSearchService.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BlogElasticSearchService.Configuration
{
    public  class ResponseTraversal
    {
        public Blog SearchResponse(JToken responseItem)
        {
             Blog _blog = new Blog();
            _blog.Id = responseItem["_source"]["id"]["S"].ToString();
            _blog.BlogAuthor = responseItem["_source"]["blogauthor"]["S"].ToString();
            _blog.BlogText = responseItem["_source"]["blogtext"]["S"].ToString();
            _blog.BlogTitle = responseItem["_source"]["blogtitle"]["S"].ToString();
            _blog.BlogCreationDate = responseItem["_source"]["blogcreationdate"]["S"].ToString();
            _blog.LikesCount = responseItem["_source"]["likescount"]["S"].ToString();
            _blog.Rating = responseItem["_source"]["rating"]["S"].ToString();
            return _blog;
        }

        public Blog PersonalizedFeedResponse(JToken responseItem)
        {
            Blog _blog = new Blog();
            _blog.Id = responseItem["_source"]["id"]["S"].ToString();
            _blog.BlogAuthor = responseItem["_source"]["blogauthor"]["S"].ToString();
            _blog.BlogText = responseItem["_source"]["blogtext"]["S"].ToString();
            _blog.BlogTitle = responseItem["_source"]["blogtitle"]["S"].ToString();
            _blog.BlogCreationDate = responseItem["_source"]["blogcreationdate"]["S"].ToString();
            _blog.LikesCount = responseItem["_source"]["likescount"]["S"].ToString();
            _blog.Rating = responseItem["_source"]["rating"]["S"].ToString();

            var TagList = JsonConvert.DeserializeObject<List<string>>(responseItem["_source"]["blogtags"]["SS"].ToString());
            _blog.BlogTags = String.Join(",", TagList);
            return _blog;
        }
    }
}
