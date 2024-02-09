namespace blog_api.Models;

public class ArticleRequest
{
  public string Title { get; set; }
  public string ImageUrl { get; set; }
  public string Description { get; set; }
  public string AuthorName { get; set; }
  public string IpAddress { get; set; }
  public DateTime CreatedDate { get; set; }
}
