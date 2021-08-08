using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementaion of product review management");

            ReviewManager review = new ReviewManager();
            review.AddReviews();
            Console.WriteLine("1.Top3Ratedproduct\n2.RetrivalRecordRatingGreaterThan3\n3.CountOfUser");
            Console.WriteLine("4.RetriveOnlyProductId\n5.SkipTop5Record");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    review.Top3RatedProduct();
                    break;

                case 2:
                    review.IterateMethod(review.RetrivalRecordRatingGreaterThan3());
                    break;
                case 3:
                    review.CountOfUser();
                    break;
                case 4:
                    review.RetriveOnlyProductId();
                    break;
                case 5:
                    review.IterateMethod(review.SkipTop5Record());
                    break;
                default:
                    Console.WriteLine("enter valid choice");
                    break;

            }
           

            Console.Read();
        }
        
    }
}
