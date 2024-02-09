namespace blog_api.Models;

public class Article
{
  public int ArticleId { get; set; }
  public string Title { get; set; }
  public string ImageUrl { get; set; }
  public string Description { get; set; }
  public string AuthorName { get; set; }
  public string IpAddress { get; set; }

  public List<Comment> Comments { get; set; }
  public bool isDeleted { get; set; }
  public DateTime CreatedDate { get; set; }
}
