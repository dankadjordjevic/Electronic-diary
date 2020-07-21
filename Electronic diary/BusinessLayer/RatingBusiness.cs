using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RatingBusiness
    {
        private IRatingRepository ratingRepository;

        public RatingBusiness(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public List<Rating> GetAllRatingsAVG(string personalId)
        {
            return this.ratingRepository.GetAllRatingsAVG(personalId);
        }

        public List<Rating> GetAllRatings()
        {
            return this.ratingRepository.GetAllRatings();
        }

        public void InsertRating(Rating r)
        {
            this.ratingRepository.InsertRating(r);
        }

        public void DeleteRating(Rating r)
        {
            this.ratingRepository.DeleteRating(r);
        }

        public void UpdateRating(Rating r)
        {
            this.ratingRepository.UpdateRating(r);
        }

        public List<Rating> GetAllRatingById(int id)
        {
            return this.ratingRepository.GetAllRatings().Where(c => c.GetSetId == id).ToList();
        }
    }
}