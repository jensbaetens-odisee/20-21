using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    public interface IQuoteRepository
    {
        List<Quote> GetAllQuotes();
        void AddQuote(Quote quote);
        void DeleteQuote(Quote quote);
        void UpdateQuote(Quote quote);
        Quote GetQuote(int id);
    }
    public class QuoteRepository : IQuoteRepository
    {

        QuoteDbContext dbContext;

        public QuoteRepository(): this(new QuoteDbContext())
        {

        }

        public QuoteRepository(QuoteDbContext quoteDbContext)
        {
            this.dbContext = quoteDbContext;
        }

        public void AddQuote(Quote quote)
        {
            dbContext.Quotes.Add(quote);
            dbContext.SaveChanges();
        }

        public void DeleteQuote(Quote quote)
        {
            dbContext.Quotes.Remove(quote);
            dbContext.SaveChanges();
        }

        public List<Quote> GetAllQuotes()
        {
            return dbContext.Quotes.ToList();
        }

        public Quote GetQuote(int id)
        {
            return dbContext.Quotes.First(quote => quote.Id == id);
        }

        public void UpdateQuote(Quote quote)
        {
            dbContext.Entry<Quote>(quote).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
