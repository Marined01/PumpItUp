-- Міграція для створення таблиці user_workout_progress
CREATE TABLE user_workout_progress (
    progressid SERIAL PRIMARY KEY,
    userid INT REFERENCES users(userid) ON DELETE CASCADE,
    workoutid INT REFERENCES workouts(workoutid) ON DELETE CASCADE,
    progress_percentage DECIMAL(5,2) CHECK (progress_percentage BETWEEN 0 AND 100),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
