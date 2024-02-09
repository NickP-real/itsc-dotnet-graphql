using blog_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_api.GraphQL;

public class Query
{
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Article> GetArticles([Service] BlogDbContext context)
  {
    return context.Articles;
  }

  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Comment> GetComments([Service] BlogDbContext context)
  {
    return context.Comments.Include(e => e.Article);
  }
}
