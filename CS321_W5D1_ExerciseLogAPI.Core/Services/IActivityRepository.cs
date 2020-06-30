using System;
using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        // create
        Activity Add(Activity todo);
        // read
        Activity Get(int id);
        // update
        Activity Update(Activity todo);
        // delete
        void Remove(Activity todo);
        // list
        IEnumerable<Activity> GetAll();

        // TODO: Class Project: Add GetAllForUser method
        IEnumerable<Activity> GetAllForUser(string userId);

        public IEnumerable<Activity> GetAllForUser(string userId)
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .Where(a => a.UserId == userId) // only for the given user
                .ToList();
        }

    }
}
