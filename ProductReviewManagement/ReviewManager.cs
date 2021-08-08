using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ProductReviewManagement
{
   public class ReviewManager
    {
        List<ProductReview> Product;
        public ReviewManager()
        {
            Product = new List<ProductReview>();
        }
        //UC1-Adding 25 Reviews
        public List<ProductReview> AddReviews()
        {
            Product.Add(new ProductReview() { productId = 1, userId = 3, rating = 10, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 7, userId = 6, rating = 3, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 3, userId = 11, rating = 5, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 8, userId = 67, rating = 20, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 2, userId = 3, rating = 14, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 6, userId = 5, rating = 7, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 1, userId = 9, rating = 2, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 8, userId = 2, rating = 0, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 5, userId = 6, rating = 7, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 4, userId = 11, rating = 6, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 10, userId = 78, rating = 4, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 3, userId = 23, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 8, rating = 8, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 2, userId = 1, rating = 17, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 7, userId = 6, rating = 19, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 1, userId = 9, rating = 13, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 2, rating = 5, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 4, userId = 5, rating = 3, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 6, userId = 1, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 2, userId = 5, rating = 1, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 8, userId = 9, rating = 18, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 3, userId = 9, rating = 13, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 5, userId = 1, rating = 4, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 6, userId = 5, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 10, rating = 5, review = "bad", isLike = false });
            return Product;
        }

        public void IterateMethod(List<ProductReview> products)
        {
            foreach (ProductReview p in products)
            {
                Console.WriteLine("Product Id:{0}\tUser Id:{1}\tRating:{2}\tReview:{3}\tIsLike:{4}", p.productId, p.userId, p.rating, p.review, p.isLike);
            }
        }
        //UC2-Retrive top3  rated product from the list
        public List<ProductReview> Top3RatedProduct()
        {
            var res = (from product in Product orderby product.rating descending select product).Take(3).ToList();
            Console.WriteLine("Top 3 products");
            return res;
        }

        //UC3-Retrive All record or product rating greater than 3 and product id is 1 or 4 or 9
        public List<ProductReview> RetrivalRecordRatingGreaterThan3()
        {
            List<ProductReview> res = null;
            res = (from product in Product where (product.rating > 3) && (product.productId == 1 || product.productId == 4 || product.productId == 9) select product).ToList();
            return res;
        }

        //UC3-Count of person gave review
        public string CountOfUser()
        {

            string result = "";
            var res = Product.GroupBy(p => p.productId).Select(x => new { productId = x.Key, count = x.Count() });
            foreach (var r in res)
            {
                Console.WriteLine("Product Id:{0}\tCount:{1}", r.productId, r.count);
                result += "" + r.productId + " " + r.count + " ";
            }
            return result;
        }
        //UC5-Retrive product Id from list
        public void RetriveOnlyProductId()
        {
            var res = from product in Product
                      select new
                      {
                          productId = product.productId,
                          review = product.review
                      };
            foreach (var r in res)
            {
                Console.WriteLine("Product Id:{0}\tReview:{1}", r.productId, r.review);
            }

        }
        //UC6-Skip top 5 records
        public List<ProductReview> SkipTop5Record()
        {
            var res = (from product in Product orderby product.rating descending select product).Skip(5).ToList();
            return res;
        }

        //UC7-Retrive product Id from list
        public int[] RetriveOnlyProductIdMethod()
        {
            int[] res = Product.Select(x => x.productId).ToArray();
            return res;
        }
        public void IterateTable(DataTable table)
        {
            var res = (from table1 in table.AsEnumerable() select table1.Field<string>("ProductId")).ToList();
            foreach (var p in res)
            {
                Console.WriteLine(p);
            }

        }
        //UC8-AverageOfRating
        public string AverageOfRating()
        {
            string result = "";
            var res = Product.GroupBy(p => p.productId, r => r.rating).Select(x => new { productId = x.Key, average = x.Average() });
            foreach (var r in res)
            {
                Console.WriteLine("Product Id:{0}\tAverageOfRating:{1}", r.productId, r.average);
                result += "" + r.productId + " " + r.average + " ";
            }
            return result;
        }

        //UC9-retriving RecordBased on review
        public List<ProductReview> RetrivingBasedOnReview(string review)
        {
            List<ProductReview> res = Product.Where(x => x.review.Equals(review)).ToList();
            return res;

        }

        //UC10-Creating the data table 
        public void CreateDataTable(List<ProductReview> list)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("rating");
            dataTable.Columns.Add("Reviews");
            dataTable.Columns.Add("IsLike");
            foreach (var l in list)
            {
                dataTable.Rows.Add(l.productId, l.userId, l.rating, l.review, l.isLike);
            }
            IterateTable(dataTable);
        }
    }
}
