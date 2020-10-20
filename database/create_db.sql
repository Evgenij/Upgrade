
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
	text TEXT NOT NULL CHECK(length(text) != 0),
	FOREIGN KEY (id_user) REFERENCES user (id_user)
);

CREATE TABLE "password" 
(
	id_pass INTEGER PRIMARY KEY AUTOINCREMENT,
	id_user INTEGER NOT NULL,
	name_serv TEXT NOT NULL CHECK(length(name_serv) > 0),
	login TEXT NOT NULL CHECK(length(login) > 0),
	password TEXT NOT NULL CHECK(length(password) > 0),
	em_ph TEXT NULL
);

CREATE TABLE "user" 
(
	id_user INTEGER PRIMARY KEY AUTOINCREMENT,
	photo BLOB NULL,
	login TEXT NOT NULL CHECK(length(login) != 0),
	password TEXT NOT NULL CHECK(length(password) > 0),
	email TEXT NULL,
	reg_code TEXT NOT NULL CHECK(length(reg_code) == 4),
	perform INTEGER NOT NULL
);

CREATE TABLE "direction" 
(
	id_direct INTEGER PRIMARY KEY AUTOINCREMENT,
	id_categ INTEGER NOT NULL, 
	name TEXT NOT NULL CHECK(length(name) > 0),
	compliting INTEGER NOT NULL CHECK(compliting >= 0 AND compliting <= 100),
	color_mark TEXT NOT NULL
);

/*таблица категорий с фиксированными данными, данные не меняются в процессе работы приложения*/
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
	status INTEGER NOT NULL CHECK(status == 0 OR status == 1)
);

CREATE TABLE "target" 
(
	id_target INTEGER PRIMARY KEY AUTOINCREMENT,
	id_direct INTEGER NOT NUll,
	name TEXT NOT NULL,
	compliting INTEGER NOT NULL CHECK(compliting >= 0 AND compliting <= 100),
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
	date TEXT NOT NULL DEFAULT CURRENT_DATE,
	time TEXT NULL  DEFAULT CURRENT_TIME,
	time_finish TEXT NULL,
	failed INTEGER NOT NULL CHECK(failed == 0 OR failed == 1),
	status INTEGER NOT NULL CHECK(status == 0 OR status == 1),
	FOREIGN KEY (id_target) REFERENCES target(id_target),
	FOREIGN KEY (id_sched) REFERENCES schedule (id_sched)
);

CREATE TABLE "subtask" 
(
	id_subtask INTEGER PRIMARY KEY AUTOINCREMENT,
	id_task INTEGER NOT NUll,
	text TEXT NOT NULL CHECK(length(text) > 0),
	status INTEGER NOT NULL CHECK(status == 0 OR status == 1),
	FOREIGN KEY (id_task) REFERENCES task (id_task) ON DELETE CASCADE
);

CREATE TABLE "schedule" 
(
	id_sched INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL CHECK(length(name) > 0)
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

INSERT INTO user VALUES (NULL, NULL, "Rampad", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "1652", 85);
INSERT INTO user VALUES (NULL, NULL, "Spike", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "6532", 55);
INSERT INTO user VALUES (NULL, NULL, "Igenaric", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "1236", 25);
INSERT INTO user VALUES (NULL, NULL, "Netris", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "4672", 35);
INSERT INTO user VALUES (NULL, NULL, "_coffeiok_", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "4672", 55);

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
	(NULL, 1, "Повседневные дела", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 2, "Работа", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Мой бизнес", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Магазин 'Flora'", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 4, "Семья", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Гитара", 50, "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Футбол", 50, "#323232");

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
	(NULL, "Энтузиаст", "Описание", 13, 0);
INSERT INTO achievement
VALUES
	(NULL, "Триумфатор", "Описание", 0, 0);
INSERT INTO achievement
VALUES
	(NULL, "Покоритель", "Описание", 10, 1);
INSERT INTO achievement
VALUES
	(NULL, "Душа компании", "Описание",  10, 0);
INSERT INTO achievement
VALUES
	(NULL, "Воин выходного дня", "Описание", 3, 1);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг6", "Описание", 7, 0);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг7", "Описание", 5, 1);
INSERT INTO achievement
VALUES
	(NULL, "Первый шаг8", "Описание", 5, 1);

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
	(NULL, 1, "Сделать ремонт", 70);
INSERT INTO target
VALUES
	(NULL, 1, "Утеплить окна", 100);
INSERT INTO target
VALUES
	(NULL, 2, "Перевыполнить план", 65);
INSERT INTO target
VALUES
	(NULL, 2, "Повысить охват рекламы", 40);
INSERT INTO target
VALUES
	(NULL, 2, "Разработать систему скидок", 66);

INSERT INTO schedule
VALUES
	(NULL, "Расписание №1");
INSERT INTO schedule
VALUES
	(NULL, "Расписание №2");
INSERT INTO schedule
VALUES
	(NULL, "Расписание №3");
INSERT INTO schedule
VALUES
	(NULL, "Расписание №4");

	




