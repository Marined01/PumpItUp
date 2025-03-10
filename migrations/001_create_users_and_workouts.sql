CREATE TABLE users (
    userid SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    passwordhash TEXT NOT NULL,
    role VARCHAR(20) CHECK (role IN ('GUEST', 'USER', 'PREMIUM_USER', 'ADMIN')) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE workouts (
    workoutid SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    difficulty_level VARCHAR(50),
    duration INT,  -- в хвилинах
    video_url VARCHAR(255),
    created_by INT REFERENCES users(userid),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
