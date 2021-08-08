using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProductReviewManagement;
using System.Collections.Generic;

namespace ProductReviewTest
{
    [TestClass]
    public class UnitTest1
    {
        ReviewManager review;
        [TestInitialize]
        public void TestSetUp()
        {
            review = new ReviewManager();
            List<ProductReview> list = review.AddReviews();
        }
        [TestMethod]
        //UC2-Retrive top3  rated product from the list
        public void Top3BYRatingTest()
        {
            List<ProductReview> expected = new List<ProductReview> { new ProductReview() { productId = 8, userId = 67, rating = 20, review = "good", isLike = true }, new ProductReview() { productId = 7, userId = 6, rating = 19, review = "good", isLike = true }, new ProductReview() { productId = 8, userId = 9, rating = 18, review = "good", isLike = true } };
            List<ProductReview> actual = review.Top3RatedProduct();
            expected.Equals(actual);
        }
        [TestMethod]
        //UC3-Count of person gave review
        public void CountOfUserReviewAProduct()
        {
            string expected = "1 3 7 2 3 3 8 3 2 3 6 3 5 2 4 2 10 1 9 3 ";
            string actual = review.CountOfUser();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //UC4-Retrive all products data whoes rating greater than 3 and product id 1,4 or 9
        public void AllRecordRetrivalTest()
        {
            List<ProductReview> expected = new List<ProductReview> { new ProductReview() { productId = 1, userId = 3, rating = 10, review = "Average", isLike = true }, new ProductReview() { productId = 4, userId = 11, rating = 6, review = "bad", isLike = false }, new ProductReview() { productId = 9, userId = 8, rating = 8, review = "Average", isLike = true }, new ProductReview() { productId = 1, userId = 9, rating = 13, review = "good", isLike = true }, new ProductReview() { productId = 9, userId = 2, rating = 5, review = "bad", isLike = false }, new ProductReview() { productId = 9, userId = 10, rating = 5, review = "bad", isLike = false } };
            List<ProductReview> actual = review.RetrivalRecordRatingGreaterThan3();
            expected.Equals(actual);
        }

        [TestMethod]
        //Uc5-Skiping top5 records
        public void SkipTop5Record()
        {
            //Assign
            List<ProductReview> Product = new List<ProductReview>();
            Product.Add(new ProductReview() { productId = 1, userId = 3, rating = 10, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 7, userId = 6, rating = 3, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 3, userId = 11, rating = 5, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 6, userId = 5, rating = 7, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 1, userId = 9, rating = 2, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 8, userId = 2, rating = 0, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 5, userId = 6, rating = 7, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 4, userId = 11, rating = 6, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 10, userId = 78, rating = 4, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 3, userId = 23, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 8, rating = 8, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 1, userId = 9, rating = 13, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 2, rating = 5, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 4, userId = 5, rating = 3, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 6, userId = 1, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 2, userId = 5, rating = 1, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 3, userId = 9, rating = 13, review = "good", isLike = true });
            Product.Add(new ProductReview() { productId = 5, userId = 1, rating = 4, review = "bad", isLike = false });
            Product.Add(new ProductReview() { productId = 6, userId = 5, rating = 9, review = "Average", isLike = true });
            Product.Add(new ProductReview() { productId = 9, userId = 10, rating = 5, review = "bad", isLike = false });
            //Act
            List<ProductReview> actual = review.RetrivalRecordRatingGreaterThan3();
            Product.Equals(actual);

        }

        //UC7- Retrive product id
        public void RetriveProductId2()
        {
            string expected = "1 7 3 8 2 6 1 8 5 4 10 3 9 2 7 1 9 4 6 2 8 3 5 6 9 ";
            int[] list = review.RetriveOnlyProductIdMethod();
            string actual = "";
            foreach (var l in list)
            {
                actual += "" + l + " ";
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //UC8-Average by rating
        public void AverageOfProductRating()
        {
            string expected = "1 8.333333333333334 7 11 3 9 8 12.666666666666666 2 10.666666666666666 6 8.333333333333334 5 5.5 4 4.5 10 4 9 6"; 

            string actual = review.AverageOfRating();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //UC9-Retrive recors based on review
        public void RetriveProductBasedOnReview()
        {
            int expected = 6;
            var list = review.RetrivingBasedOnReview("good");
            int actual = list.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
