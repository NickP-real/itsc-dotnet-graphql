using blog_api.Models;

namespace blog_api.GraphQL;

public class Mutation
{
  public async Task<Article> AddArticle(ArticleRequest articleRequest, [Service] BlogDbContext context)
  {
    Article article = new()
    {
      Title = articleRequest.Title,
      AuthorName = articleRequest.AuthorName,
      ImageUrl = articleRequest.ImageUrl,
      IpAddress = articleRequest.IpAddress,
      Description = articleRequest.Description,

      CreatedDate = articleRequest.CreatedDate
    };

    context.Add(article);
    await context.SaveChangesAsync();
    return article;
  }

  public async Task<Comment> AddComment(CommentRequest commentRequest, [Service] BlogDbContext context)
  {
    Comment comment = new()
    {
      ArticleId = commentRequest.ArticleId,
      IpAddress = commentRequest.IpAddress,
      Message = commentRequest.Message,

      CreatedDate = DateTime.UtcNow
    };

    context.Add(comment);
    await context.SaveChangesAsync();
    return comment;
  }

  public async Task<bool> UpdateArticleById(int articleId, ArticleRequest articleRequest, [Service] BlogDbContext context)
  {
    Article existingArticle = await context.Articles.FindAsync(articleId);
    if (existingArticle == null || existingArticle.isDeleted) return false;

    existingArticle.Title = articleRequest.Title;
    existingArticle.AuthorName = articleRequest.AuthorName;
    existingArticle.Description = articleRequest.Description;
    existingArticle.ImageUrl = articleRequest.ImageUrl;
    existingArticle.IpAddress = articleRequest.IpAddress;

    context.Update(existingArticle);
    await context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> UpdateCommentById(int commentId, CommentRequest commentRequest, [Service] BlogDbContext context)
  {
    Comment exisitingComment = await context.Comments.FindAsync(commentId);
    if (exisitingComment == null) return false;

    Article existingArticle = await context.Articles.FindAsync(exisitingComment.ArticleId);
    if (existingArticle == null || existingArticle.isDeleted) return false;

    exisitingComment.Message = commentRequest.Message;
    exisitingComment.IpAddress = commentRequest.IpAddress;

    context.Update(exisitingComment);
    await context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteArticleById(int articleId, [Service] BlogDbContext context)
  {
    Article existingArticle = await context.Articles.FindAsync(articleId);
    if (existingArticle == null) return false;

    existingArticle.isDeleted = true;

    context.Update(existingArticle);
    await context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteCommentById(int commentId, [Service] BlogDbContext context)
  {
    Comment existingComment = await context.Comments.FindAsync(commentId);
    if (existingComment == null) return false;

    context.Remove(existingComment);
    await context.SaveChangesAsync();
    return true;
  }
}
