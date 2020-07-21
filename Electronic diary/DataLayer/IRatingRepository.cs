using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IRatingRepository
    {
        List<Rating> GetAllRatings();

        void InsertRating(Rating r);

        void DeleteRating(Rating r);

        void UpdateRating(Rating r);

        List<Rating> GetAllRatingsAVG(string personalId);
    }
}