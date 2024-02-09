namespace blog_api.Models;

public class Comment
{
  public int CommentId { get; set; }
  public string Message { get; set; }
  public string IpAddress { get; set; }

  public int ArticleId { get; set; }
  public Article Article { get; set; }

  public DateTime CreatedDate { get; set; }
}
