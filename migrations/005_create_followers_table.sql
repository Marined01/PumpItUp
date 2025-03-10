CREATE TABLE followers (
    followerid SERIAL PRIMARY KEY,
    userid INT REFERENCES users(userid) ON DELETE CASCADE,
    follower_userid INT REFERENCES users(userid) ON DELETE CASCADE,
    UNIQUE(userid, follower_userid)
);