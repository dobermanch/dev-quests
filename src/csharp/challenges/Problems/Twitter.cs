//https://leetcode.com/problems/design-twitter/

namespace LeetCode.Problems;

public sealed class Twitter : ProblemBase
{
    //[Theory]
    //[ClassData(typeof(Twitter))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<CustomTwitter, int[]>(config => 
                config
                    .MapConstructor("Twitter")
                    .MapInstruction("postTweet", (it, data) => it.PostTweet(data[0], data[1]))
                    .MapInstruction("getNewsFeed", (it, data) => it.GetNewsFeed(data[0]))
                    .MapInstruction("follow", (it, data) => it.Follow(data[0], data[1]))
                    .MapInstruction("unfollow", (it, data) => it.Unfollow(data[0], data[1]))
           )
           .Add(true, it => it.Data<int>("""[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]""")
                       .Instructions("""["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]""")
                       .Output("[null, null, new []{5}, null, null, new[] {6, 5}, null, new[] {5}]"))
          .Add(it => it.Data<int>("""[[],[1,1],[1],[2,1],[2],[2,1],[2]]""")
                       .Instructions("""["Twitter","postTweet","getNewsFeed","follow","getNewsFeed","unfollow","getNewsFeed"]""")
                       .Output("[null, null, new[]{1}, null, new[] { 1 }, null, new[0]]"));

    private class CustomTwitter
    {
        private const int _maxTwitsInFeed = 10;
        private readonly Dictionary<int, (IList<int> following, IList<int> followers)> _users = new();
        private readonly Dictionary<int, IList<(int user, int tweet)>> _twits = new();

        public void PostTweet(int userId, int tweetId)
        {
            if (!_users.ContainsKey(userId))
            {
                _users[userId] = (new List<int>(), new List<int>());
                _twits[userId] = new List<(int, int)>();
            }

            _twits[userId].Insert(0, (userId, tweetId));
            foreach (var followerId in _users[userId].followers)
            {
                _twits[followerId].Insert(0, (userId, tweetId));
            }
        }

        public IList<int> GetNewsFeed(int userId)
        {
            return !_users.ContainsKey(userId) ? Array.Empty<int>() : _twits[userId].Take(_maxTwitsInFeed).Select(it => it.tweet).ToArray();
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!_users.ContainsKey(followerId))
            {
                _users[followerId] = (new List<int>(), new List<int>());
                _twits[followerId] = new List<(int, int)>();
            }

            _users[followerId].following.Add(followeeId);

            if (!_users.ContainsKey(followeeId))
            {
                _users[followeeId] = (new List<int>(), new List<int>());
                _twits[followeeId] = new List<(int, int)>();
            }

            _users[followeeId].followers.Add(followerId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (_users.TryGetValue(followerId, out var user))
            {
                user.following.Remove(followeeId);
                var toRemove = _twits[followerId].Where(it => it.user == followeeId).ToArray();
                foreach (var tweet in toRemove)
                {
                    _twits[followerId].Remove(tweet);
                }
            }

            if (_users.TryGetValue(followeeId, out user))
            {
                user.followers.Remove(followerId);
            }
        }
    }
}