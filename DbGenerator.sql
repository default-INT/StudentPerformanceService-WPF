CREATE DATABASE student_performance_service;

CREATE TABLE faculties (
    id serial primary key not null ,
    name text not null unique
);

CREATE TABLE specialties (
    id serial primary key not null ,
    name text not null ,
    faculty_id int not null,
    foreign key (faculty_id) references faculties (id)
);

CREATE TABLE groups (
    id serial primary key not null ,
    name text not null ,
    semester int not null ,
    specialty_id int not null,
    foreign key (specialty_id) references specialties (id)
);

CREATE TABLE accounts (
    id serial primary key not null ,
    login text not null unique ,
    password text not null ,
    full_name text not null ,
    role int not null ,
    group_id int,
    foreign key (group_id) references groups (id)
);

CREATE TABLE subjects (
    id serial primary key  not null ,
    name text not null ,
    teacher text not null
);

CREATE TABLE subjects_specialties (
    id serial primary key not null ,
    subject_id int not null ,
    specialty_id int not null ,
    foreign key (subject_id) references subjects (id),
    foreign key (specialty_id) references specialties (id)
);

CREATE TABLE sessions (
    id serial primary key not null ,
    year int not null ,
    season boolean
);

CREATE TABLE tests (
    id serial primary key  not null ,
    date date not null ,
    subject_id int not null ,
    group_id int not null ,
    type int not null ,
    semester int not null,
    session_id int not null ,
    foreign key (subject_id) references subjects (id),
    foreign key (group_id) references groups (id),
    foreign key (session_id) references sessions (id)
);

CREATE TABLE test_results (
    id serial primary key not null ,
    test_id int not null ,
    student_id int not null ,
    completion_date date not null ,
    mark int not null ,
    attempts_number int not null ,
    foreign key (test_id) references tests (id),
    foreign key (student_id) references accounts (id)
);


INSERT INTO accounts(login, password, full_name, role) VALUES ('admin', 'a1806', 'Семуткин А.А.', 0);
    INSERT INTO accounts(login, password, full_name, role) VALUES ('methodist', 'm1806', 'Липский Д.Ю.', 1);

INSERT INTO faculties(name) VALUES ('ФАИС');
INSERT INTO faculties(name) VALUES ('ЭФ');
INSERT INTO faculties(name) VALUES ('ГЭФ');

INSERT INTO specialties(name, faculty_id) VALUES ('Информационные системы и технологии (в производстве)', 1);
INSERT INTO specialties(name, faculty_id) VALUES ('Информационные системы и технологии (в игровой индустрии)', 1);
INSERT INTO specialties(name, faculty_id) VALUES ('Энергетические системы и сети', 2);
INSERT INTO specialties(name, faculty_id) VALUES ('Элекстроснабжение', 2);
INSERT INTO specialties(name, faculty_id) VALUES ('Экономика и управление на предприятии', 3);
INSERT INTO specialties(name, faculty_id) VALUES ('Менеджмент', 3);

INSERT INTO groups (name, semester, specialty_id) VALUES ('ИТП-21', 4, 1);
INSERT INTO groups (name, semester, specialty_id) VALUES ('ИТИ-21', 4, 2);
INSERT INTO groups (name, semester, specialty_id) VALUES ('ЭС-31', 6, 3);
INSERT INTO groups (name, semester, specialty_id) VALUES ('ЭН-31', 6, 4);
INSERT INTO groups (name, semester, specialty_id) VALUES ('ЭП-11', 2, 5);
INSERT INTO groups (name, semester, specialty_id) VALUES ('М-11', 2, 6);

INSERT INTO accounts(login, password, full_name, role, group_id) VALUES ('ropot', 's1806', 'Ропот И.В.', 2, 1);
INSERT INTO accounts(login, password, full_name, role, group_id) VALUES ('solod', 's1806', 'Солодков М.А.', 2, 2);
INSERT INTO accounts(login, password, full_name, role, group_id) VALUES ('dekker', 's1806', 'Герасименко М.В.', 2, 1);
INSERT INTO accounts(login, password, full_name, role, group_id) VALUES ('stolny', 's1806', 'Стольный Д.С.', 2, 2);
INSERT INTO accounts(login, password, full_name, role, group_id) VALUES ('sema', 's1806', 'Семёнов Д.С.', 2, 1);

INSERT INTO subjects(name, teacher) VALUES ('Высшая математика', 'Авакян Е.З.');
INSERT INTO subjects(name, teacher) VALUES ('ООП', 'Курочка К.С.');
INSERT INTO subjects(name, teacher) VALUES ('Компьютерные сети', 'Курочка К.С.');

INSERT INTO subjects_specialties (subject_id, specialty_id) VALUES (2, 1);
INSERT INTO subjects_specialties (subject_id, specialty_id) VALUES (2, 2);

INSERT INTO sessions(year, season) VALUES (2020, true);

INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-18', 2, 1, 2, 4, 1);
INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-20', 2, 2, 2, 4, 1);

INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-24', 2, 1, 1, 4, 1);
INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-26', 2, 2, 1, 4, 1);

INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-15', 1, 1, 0, 4, 1);
INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-17', 1, 2, 0, 4, 1);

INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-26', 3, 1, 1, 4, 1);
INSERT INTO tests(date, subject_id, group_id, type, semester, session_id) VALUES ('2020-06-24', 3, 2, 1, 4, 1);
