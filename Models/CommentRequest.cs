namespace blog_api.Models;

public class CommentRequest
{
  public int ArticleId { get; set; }
  public string Message { get; set; }
  public string IpAddress { get; set; }
}
