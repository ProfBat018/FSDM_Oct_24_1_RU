-- 1. Люди: 1 декан, 10 преподавателей, 100 студентов
INSERT INTO People([Name], [Surname]) VALUES
  ('Dean',    'One');    -- Id = 1

-- 10 преподавателей: PersonId = 2..11
INSERT INTO People([Name], [Surname])
VALUES
  ('Teacher1','Surname1'),
  ('Teacher2','Surname2'),
  ('Teacher3','Surname3'),
  ('Teacher4','Surname4'),
  ('Teacher5','Surname5'),
  ('Teacher6','Surname6'),
  ('Teacher7','Surname7'),
  ('Teacher8','Surname8'),
  ('Teacher9','Surname9'),
  ('Teacher10','Surname10');

-- 100 студентов: PersonId = 12..111
-- Имена Student1…Student100, фамилии Surname1…Surname100
INSERT INTO People([Name], [Surname])
SELECT
  'Student' + CAST(n AS nvarchar(3)),
  'Surname' + CAST(n AS nvarchar(3))
FROM (
  SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
  FROM (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) a(n),
       (VALUES(0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) b(n)
) AS nums
WHERE n BETWEEN 1 AND 100;


-- 2. Факультет (все группы будут к нему привязаны)
INSERT INTO Faculties([Name], [FacultyDeanId])
VALUES ('Faculty1', 1);  -- Id = 1


-- 3. Группы G01…G10, все c FacultyId = 1
INSERT INTO Groups([Name], [FacultyId])
VALUES
  ('G01', 1),
  ('G02', 1),
  ('G03', 1),
  ('G04', 1),
  ('G05', 1),
  ('G06', 1),
  ('G07', 1),
  ('G08', 1),
  ('G09', 1),
  ('G10', 1);


-- 4. Аудитории Aud01…Aud10, все вместимостью от 20 до 50 (в рамках ограничения 5–100)
INSERT INTO Auditorium([Name], [MaxPersonCount])
VALUES
  ('Aud01', 30),
  ('Aud02', 25),
  ('Aud03', 20),
  ('Aud04', 35),
  ('Aud05', 40),
  ('Aud06', 45),
  ('Aud07', 50),
  ('Aud08', 28),
  ('Aud09', 32),
  ('Aud10', 22);


-- 5. Преподаватели (Teachers), Email и PersonId = 2..11
INSERT INTO Teachers([Email], [PersonId])
VALUES
  ('teacher1@example.com',  2),
  ('teacher2@example.com',  3),
  ('teacher3@example.com',  4),
  ('teacher4@example.com',  5),
  ('teacher5@example.com',  6),
  ('teacher6@example.com',  7),
  ('teacher7@example.com',  8),
  ('teacher8@example.com',  9),
  ('teacher9@example.com', 10),
  ('teacher10@example.com',11);


-- 6. Студенты (Students), Email и PersonId = 12..111, распределение по группам:
-- G01 – 15 чел. (PersonId 12–26)
-- G02 –  9 чел. (27–35)
-- G03 – 12 чел. (36–47)
-- G04 –  8 чел. (48–55)
-- G05 – 11 чел. (56–66)
-- G06 – 10 чел. (67–76)
-- G07 –  7 чел. (77–83)
-- G08 – 13 чел. (84–96)
-- G09 –  6 чел. (97–102)
-- G10 –  9 чел. (103–111)
INSERT INTO Students([Email], [PersonId], [GroupId])
VALUES
  -- G01: 12–26
  ('student12@example.com', 12, 1),
  ('student13@example.com', 13, 1),
  ('student14@example.com', 14, 1),
  ('student15@example.com', 15, 1),
  ('student16@example.com', 16, 1),
  ('student17@example.com', 17, 1),
  ('student18@example.com', 18, 1),
  ('student19@example.com', 19, 1),
  ('student20@example.com', 20, 1),
  ('student21@example.com', 21, 1),
  ('student22@example.com', 22, 1),
  ('student23@example.com', 23, 1),
  ('student24@example.com', 24, 1),
  ('student25@example.com', 25, 1),
  ('student26@example.com', 26, 1),

  -- G02: 27–35
  ('student27@example.com', 27, 2),
  ('student28@example.com', 28, 2),
  ('student29@example.com', 29, 2),
  ('student30@example.com', 30, 2),
  ('student31@example.com', 31, 2),
  ('student32@example.com', 32, 2),
  ('student33@example.com', 33, 2),
  ('student34@example.com', 34, 2),
  ('student35@example.com', 35, 2),

  -- G03: 36–47
  ('student36@example.com', 36, 3),
  ('student37@example.com', 37, 3),
  ('student38@example.com', 38, 3),
  ('student39@example.com', 39, 3),
  ('student40@example.com', 40, 3),
  ('student41@example.com', 41, 3),
  ('student42@example.com', 42, 3),
  ('student43@example.com', 43, 3),
  ('student44@example.com', 44, 3),
  ('student45@example.com', 45, 3),
  ('student46@example.com', 46, 3),
  ('student47@example.com', 47, 3),

  -- G04: 48–55
  ('student48@example.com', 48, 4),
  ('student49@example.com', 49, 4),
  ('student50@example.com', 50, 4),
  ('student51@example.com', 51, 4),
  ('student52@example.com', 52, 4),
  ('student53@example.com', 53, 4),
  ('student54@example.com', 54, 4),
  ('student55@example.com', 55, 4),

  -- G05: 56–66
  ('student56@example.com', 56, 5),
  ('student57@example.com', 57, 5),
  ('student58@example.com', 58, 5),
  ('student59@example.com', 59, 5),
  ('student60@example.com', 60, 5),
  ('student61@example.com', 61, 5),
  ('student62@example.com', 62, 5),
  ('student63@example.com', 63, 5),
  ('student64@example.com', 64, 5),
  ('student65@example.com', 65, 5),
  ('student66@example.com', 66, 5),

  -- G06: 67–76
  ('student67@example.com', 67, 6),
  ('student68@example.com', 68, 6),
  ('student69@example.com', 69, 6),
  ('student70@example.com', 70, 6),
  ('student71@example.com', 71, 6),
  ('student72@example.com', 72, 6),
  ('student73@example.com', 73, 6),
  ('student74@example.com', 74, 6),
  ('student75@example.com', 75, 6),
  ('student76@example.com', 76, 6),

  -- G07: 77–83
  ('student77@example.com', 77, 7),
  ('student78@example.com', 78, 7),
  ('student79@example.com', 79, 7),
  ('student80@example.com', 80, 7),
  ('student81@example.com', 81, 7),
  ('student82@example.com', 82, 7),
  ('student83@example.com', 83, 7),

  -- G08: 84–96
  ('student84@example.com', 84, 8),
  ('student85@example.com', 85, 8),
  ('student86@example.com', 86, 8),
  ('student87@example.com', 87, 8),
  ('student88@example.com', 88, 8),
  ('student89@example.com', 89, 8),
  ('student90@example.com', 90, 8),
  ('student91@example.com', 91, 8),
  ('student92@example.com', 92, 8),
  ('student93@example.com', 93, 8),
  ('student94@example.com', 94, 8),
  ('student95@example.com', 95, 8),
  ('student96@example.com', 96, 8),

  -- G09: 97–102
  ('student97@example.com', 97, 9),
  ('student98@example.com', 98, 9),
  ('student99@example.com', 99, 9),
  ('student100@example.com',100, 9),
  ('student101@example.com',101, 9),
  ('student102@example.com',102, 9),

  -- G10: 103–111
  ('student103@example.com',103,10),
  ('student104@example.com',104,10),
  ('student105@example.com',105,10),
  ('student106@example.com',106,10),
  ('student107@example.com',107,10),
  ('student108@example.com',108,10),
  ('student109@example.com',109,10),
  ('student110@example.com',110,10),
  ('student111@example.com',111,10);


-- 7. Заполним таблицу Subjects
INSERT INTO Subjects([Name])
VALUES
  ('Mathematics'),
  ('Physics'),
  ('Chemistry'),
  ('Biology'),
  ('History'),
  ('Literature'),
  ('ComputerScience'),
  ('English'),
  ('Economics'),
  ('Art');


-- 8. Заполним таблицу Schedule: по одной паре для каждой группы G01…G10
INSERT INTO Schedule(SubjectId, TeacherId, GroupId, Auditorium, [Date], Duration)
VALUES
  -- группа G01 (Id=1)
  (1,  1,  1, 'Aud01', '2025-09-01 09:00', 90),
  -- группа G02 (Id=2)
  (2,  2,  2, 'Aud02', '2025-09-01 10:45', 90),
  -- группа G03 (Id=3)
  (3,  3,  3, 'Aud03', '2025-09-02 09:00', 90),
  -- группа G04 (Id=4)
  (4,  4,  4, 'Aud04', '2025-09-02 10:45', 90),
  -- группа G05 (Id=5)
  (5,  5,  5, 'Aud05', '2025-09-03 09:00', 90),
  -- группа G06 (Id=6)
  (6,  6,  6, 'Aud06', '2025-09-03 10:45', 90),
  -- группа G07 (Id=7)
  (7,  7,  7, 'Aud07', '2025-09-04 09:00', 90),
  -- группа G08 (Id=8)
  (8,  8,  8, 'Aud08', '2025-09-04 10:45', 90),
  -- группа G09 (Id=9)
  (9, 9,  9, 'Aud09', '2025-09-05 09:00', 90),
  -- группа G10 (Id=10)
  (10, 10, 10, 'Aud10', '2025-09-05 10:45', 90);
