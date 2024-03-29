

DROP TABLE IF EXISTS subtask;
DROP TABLE IF EXISTS task;
DROP TABLE IF EXISTS schedule;
DROP TABLE IF EXISTS target;
DROP TABLE IF EXISTS user_dir;
DROP TABLE IF EXISTS direction;
DROP TABLE IF EXISTS note;
DROP TABLE IF EXISTS password;
DROP TABLE IF EXISTS categ_achiev;
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS achievement;
DROP TABLE IF EXISTS user;

CREATE TABLE "note" 
(
	id_note INTEGER PRIMARY KEY AUTOINCREMENT,
	id_user INTEGER NOT NULL,
	text TEXT NOT NULL,
	FOREIGN KEY
	(id_user) REFERENCES user
	(id_user)
);

CREATE TABLE "password" 
(
	id_pass INTEGER PRIMARY KEY AUTOINCREMENT,
	id_user INTEGER NOT NULL,
	name_serv TEXT NOT NULL,
	login TEXT NOT NULL,
	password TEXT NOT NULL,
	em_ph TEXT NULL
);

CREATE TABLE "user" 
(
	id_user INTEGER PRIMARY KEY AUTOINCREMENT,
	photo BLOB NULL,
	login TEXT NOT NULL,
	password TEXT NOT NULL,
	email TEXT NULL,
	reg_code TEXT NOT NULL,
	num_achiev INTEGER NOT NULL,
	perform INTEGER NOT NULL
);

CREATE TABLE "direction" 
(
	id_direct INTEGER PRIMARY KEY AUTOINCREMENT,
	id_categ INTEGER NOT NULL, 
	name TEXT NOT NULL,
	num_tasks INTEGER NOT NULL,
	comp_tasks INTEGER NOT NULL,
	completed INTEGER NOT NULL,
	color_mark TEXT NOT NULL
);

CREATE TABLE "category" 
(
	id_categ INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE "achievement" 
(
	id_achiev INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL,
	descr TEXT NOT NULL,
	final_score INTEGER NOT NULL,
	progress INTEGER NOT NULL,
	status INTEGER NOT NULL
);

CREATE TABLE "target" 
(
	id_target INTEGER PRIMARY KEY AUTOINCREMENT,
	id_direct INTEGER NOT NUll,
	name TEXT NOT NULL,
	num_tasks INTEGER NULL,
	comp_tasks INTEGER NOT NULL,
	completed INTEGER NOT NULL,
	FOREIGN KEY
	(id_direct) REFERENCES direction
	(id_direct)
);

CREATE TABLE "task" 
(
	id_task INTEGER PRIMARY KEY AUTOINCREMENT,
	id_target INTEGER NOT NUll,
	id_sched INTEGER NULL,
	text TEXT NOT NULL,
	descr TEXT NULL,
	date TEXT NOT NULL,
	time TEXT NULL,
	time_finish TEXT NULL,
	failed INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY (id_target) REFERENCES target(id_target),
	FOREIGN KEY (id_sched) REFERENCES schedule (id_sched)
);

CREATE TABLE "subtask" 
(
	id_subtask INTEGER PRIMARY KEY AUTOINCREMENT,
	id_task INTEGER NOT NUll,
	text TEXT NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY
	(id_task) REFERENCES task
	(id_task)
);

CREATE TABLE "schedule" 
(
	id_sched INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL,
	num_tasks INTEGER NOT NULL
);

/* промежуточные таблицы для связей M:N */

CREATE TABLE "user_dir"
(
	id_user INTEGER,
	id_direct INTEGER,
	FOREIGN KEY (id_user) REFERENCES user(id_user),
	FOREIGN KEY (id_direct) REFERENCES direction(id_direct)
);

CREATE TABLE "categ_achiev"
(
	id_categ INTEGER,
	id_achiev INTEGER,
	FOREIGN KEY (id_categ) REFERENCES category(id_categ),
	FOREIGN KEY (id_achiev) REFERENCES achievement(id_achiev)
);

/* ----------------------- */

/* заполнение таблиц */

INSERT INTO user VALUES (NULL, NULL, "Ваня", "123", "email@mail.ru", "1652", 10, 45);
INSERT INTO user VALUES (NULL, NULL, "Олеся", "123", "email@mail.ru", "6532", 10, 45);
INSERT INTO user VALUES (NULL, NULL, "Игорь", "123", "email@mail.ru", "1236", 10, 45);
INSERT INTO user VALUES (NULL, NULL, "Наташа", "123", "email@mail.ru", "4672", 10, 45);

INSERT INTO note VALUES (NULL, 1, "Текст заметки №1");
INSERT INTO note VALUES (NULL, 1, "Текст заметки №2");
INSERT INTO note VALUES (NULL, 2, "Текст заметки №3");
INSERT INTO note VALUES (NULL, 2, "Текст заметки №4");
INSERT INTO note VALUES (NULL, 2, "Текст заметки №5");
INSERT INTO note VALUES (NULL, 3, "Текст заметки №6");
INSERT INTO note VALUES (NULL, 3, "Текст заметки №7");
INSERT INTO note VALUES (NULL, 4, "Текст заметки №8");
INSERT INTO note VALUES (NULL, 4, "Текст заметки №9");
INSERT INTO note VALUES (NULL, 4, "Текст заметки №10");
INSERT INTO note VALUES (NULL, 4, "Текст заметки №11");

INSERT INTO password
VALUES
	(NULL, 1, "Вконтакте", "login", "password №1", "email@mail.ru");
INSERT INTO password
VALUES
	(NULL, 1, "Вконтакте", "login", "password №2", "0714148150");
INSERT INTO password
VALUES
	(NULL, 2, "Вконтакте", "login", "password №3", "email@mail.ru");
INSERT INTO password
VALUES
	(NULL, 3, "Вконтакте", "login", "password №4", "0714148150");
INSERT INTO password
VALUES
	(NULL, 4, "Вконтакте", "login", "password №5", "0714148150");

INSERT INTO direction
VALUES
	(NULL, 1, "Повседневные дела", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 2, "Работа", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Мой бизнес", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Магазин 'Flora'", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 4, "Семья", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Гитара", 30, 15, 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Футбол", 30, 15, 50, "#323232");

INSERT INTO user_dir
VALUES
	(1, 1);
INSERT INTO user_dir
VALUES
	(1, 2);
INSERT INTO user_dir
VALUES
	(2, 3);
INSERT INTO user_dir
VALUES
	(2, 4);
INSERT INTO user_dir
VALUES
	(3, 1);
INSERT INTO user_dir
VALUES
	(3, 3);
INSERT INTO user_dir
VALUES
	(4, 2);
INSERT INTO user_dir
VALUES
	(4, 4);

INSERT INTO achievement
VALUES
	(NULL, "Первый шаг1", "Описание", 20, 13, 0);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг2", "Описание", 1, 0, 0);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг3", "Описание", 10, 10, 1);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг4", "Описание", 20, 10, 0);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг5", "Описание", 3, 3, 1);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг6", "Описание", 10, 7, 0);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг7", "Описание", 5, 5, 1);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг8", "Описание", 5, 5, 1);

INSERT INTO category
VALUES
	(NULL, "Без категории");
INSERT INTO category
VALUES
	(NULL, "Работа");
INSERT INTO category
VALUES
	(NULL, "Бизнес");
INSERT INTO category
VALUES
	(NULL, "Отношения");
INSERT INTO category
VALUES
	(NULL, "Хобби");

INSERT INTO categ_achiev
VALUES
	(1, 1);
INSERT INTO categ_achiev
VALUES
	(2, 2);
INSERT INTO categ_achiev
VALUES
	(3, 3);
INSERT INTO categ_achiev
VALUES
	(3, 4);
INSERT INTO categ_achiev
VALUES
	(4, 5);
INSERT INTO categ_achiev
VALUES
	(5, 6);
INSERT INTO categ_achiev
VALUES
	(5, 7);

INSERT INTO target
VALUES
	(NULL, 1, "Сделать ремонт", 10, 7, 70);
INSERT INTO target
VALUES
	(NULL, 1, "Утеплить окна", 5, 5, 100);
INSERT INTO target
VALUES
	(NULL, 2, "Перевыполнить план", 20, 13, 65);
INSERT INTO target
VALUES
	(NULL, 3, "Повысить охват рекламы", 10, 4, 40);
INSERT INTO target
VALUES
	(NULL, 3, "Разработать систему скидок", 3, 2, 66);

INSERT INTO schedule
VALUES
	(NULL, "Расписание №1", 2);
INSERT INTO schedule
VALUES
	(NULL, "Расписание №2", 3);
INSERT INTO schedule
VALUES
	(NULL, "Расписание №3", 1);
INSERT INTO schedule
VALUES
	(NULL, "Расписание №4", 2);

INSERT INTO task
VALUES
	(NULL, 1, 1, "Задача №1", "Описание", "08.07.2020", "12:40", "13:30", 0, 0);
INSERT INTO task
VALUES
	(NULL, 1, 1, "Задача №2", "Описание", "08.07.2020", "09:35", "11:30", 0, 0);
INSERT INTO task
VALUES
	(NULL, 2, NULL, "Задача №1", "Описание", "08.07.2020", "14:20", "15:30", 0, 0);
INSERT INTO task
VALUES
	(NULL, 2, NULL, "Задача №2", NULL, "15.06.2020", "08:50", "09:20", 0, 1);
INSERT INTO task
VALUES
	(NULL, 3, 2, "Задача №1", "Описание", "17.06.2020", "09:00", "10:30", 1, 0);
INSERT INTO task
VALUES
	(NULL, 3, 2, "Задача №2", "Описание", "14.06.2020", "10:00", "13:30", 0, 0);
INSERT INTO task
VALUES
	(NULL, 3, 2, "Задача №3", NULL, "22.06.2020", "11:50", "14:30", 1, 0);
INSERT INTO task
VALUES
	(NULL, 4, 3, "Задача №1", "Описание", "26.06.2020", "16:30", "17:30", 0, 1);
INSERT INTO task
VALUES
	(NULL, 5, 4, "Задача №1", "Описание", "03.06.2020", "18:30", "19:30", 0, 0);
INSERT INTO task
VALUES
	(NULL, 5, 4, "Задача №2", NULL, "21.06.2020", "22:00", "24:00", 0, 0);

INSERT INTO subtask
VALUES
	(NULL, 1, "Подзадача №1", 1);
INSERT INTO subtask
VALUES
	(NULL, 1, "Подзадача №2", 0);
INSERT INTO subtask
VALUES
	(NULL, 2, "Подзадача №1", 1);
INSERT INTO subtask
VALUES
	(NULL, 2, "Подзадача №2", 0);
INSERT INTO subtask
VALUES
	(NULL, 3, "Подзадача №1", 1);




