-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table.
-- Answer: The Jobs table has the following columns and data types:
-- id - int(11)
-- name - varchar(255)
-- employer_id - int(11)
-- location_id - int(11)
-- skill_id - int(11)
-- core_competency_id - int(11)



--Part 2: Write a query to list the names of the employers in St. Louis City.
SELECT employers.name
FROM employers
JOIN jobs ON jobs.employer_id = employers.id
JOIN locations ON jobs.location_id = locations.id
WHERE locations.name = 'St. Louis City';

--Part 3: Write a query to return a list of the names and descriptions of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.

    SELECT s.Name, s.Description
FROM Skills s
INNER JOIN JobSkills js ON s.SkillId = js.SkillId
ORDER BY s.Name ASC;