CREATE TABLE likes (
    likeid SERIAL PRIMARY KEY,
    userid INT REFERENCES users(userid) ON DELETE CASCADE,
    postid INT REFERENCES posts(postid) ON DELETE CASCADE,
    UNIQUE(userid, postid)
);
