
DROP TABLE IF EXISTS sched_task;
DROP TABLE IF EXISTS user_dir;
DROP TABLE IF EXISTS user_achiev;
DROP TABLE IF EXISTS achiev_categ;

DROP TABLE IF EXISTS subtask;
DROP TABLE IF EXISTS schedule;
DROP TABLE IF EXISTS day;
DROP TABLE IF EXISTS task;
DROP TABLE IF EXISTS target;
DROP TABLE IF EXISTS direction;
DROP TABLE IF EXISTS note;
DROP TABLE IF EXISTS data_service;
DROP TABLE IF EXISTS achievement;
DROP TABLE IF EXISTS category;

DROP TABLE IF EXISTS user;

CREATE TABLE "note" 
(
	id_note INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	id_user INTEGER NOT NULL,
	text TEXT NOT NULL CHECK(length(text) != 0),
	FOREIGN KEY (id_user) REFERENCES user (id_user)
);

CREATE TABLE "data_service" 
(
	id_service INTEGER NOT NULL, 
	id_user INTEGER NOT NULL,
	login TEXT NOT NULL CHECK(length(login) > 0),
	password TEXT NOT NULL CHECK(length(password) > 0),
	em_ph TEXT NULL,
	FOREIGN KEY (id_user) REFERENCES user (id_user)
);

CREATE TABLE "user" 
(
	id_user INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	photo TEXT NULL,
	login TEXT NOT NULL CHECK(length(login) != 0),
	password TEXT NOT NULL CHECK(length(password) > 0),
	email TEXT NULL,
	reg_code TEXT NOT NULL CHECK(length(reg_code) == 4)
);

CREATE TABLE "direction" 
(
	id_direct INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	id_categ INTEGER NOT NULL, 
	name TEXT NOT NULL CHECK(length(name) > 0),
	color_mark TEXT NOT NULL,
	FOREIGN KEY (id_categ) REFERENCES category(id_categ)
);

/*таблица категорий с фиксированными данными, данные не меняются в процессе работы приложения*/
CREATE TABLE "category" 
(
	id_categ INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	name TEXT NOT NULL
);

CREATE TABLE "achievement" 
(
	id_achiev INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	name TEXT NOT NULL,
	descr TEXT NOT NULL,
	final_score INTEGER NOT NULL
);

CREATE TABLE "target" 
(
	id_target INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	id_direct INTEGER NOT NUll,
	name TEXT NOT NULL,
	FOREIGN KEY (id_direct) REFERENCES direction(id_direct)
);

CREATE TABLE "task" 
(
	id_task INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	id_target INTEGER NOT NUll,
	text TEXT NOT NULL,
	descr TEXT NULL,
	date TEXT NOT NULL DEFAULT CURRENT_DATE,
	time TEXT NULL  DEFAULT CURRENT_TIME,
	time_finish TEXT NULL,
	failed INTEGER NOT NULL CHECK(failed == 0 OR failed == 1),
	status INTEGER NOT NULL CHECK(status == 0 OR status == 1),
	FOREIGN KEY (id_target) REFERENCES target(id_target)
);

CREATE TABLE "subtask" 
(
	id_subtask INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	id_task INTEGER NOT NUll,
	text TEXT NOT NULL CHECK(length(text) > 0),
	status INTEGER NOT NULL DEFAULT 0 CHECK(status == 0 OR status == 1),
	FOREIGN KEY (id_task) REFERENCES task (id_task) ON DELETE CASCADE
);

CREATE TABLE "day" 
(
	id_day INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	name TEXT NOT NULL CHECK(length(name) > 0)
);

CREATE TABLE "schedule" 
(
	id_sched INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	name TEXT NOT NULL CHECK(length(name) > 0)
);

/* промежуточные таблицы для связей M:N */

CREATE TABLE "user_dir"
(
	id_user INTEGER,
	id_direct INTEGER,
	FOREIGN KEY (id_user) REFERENCES user(id_user) ON DELETE CASCADE,
	FOREIGN KEY (id_direct) REFERENCES direction(id_direct) ON DELETE CASCADE
);

CREATE TABLE "user_achiev"
(
	id_user INTEGER,
	id_achiev INTEGER,
	current_score INTEGER NOT NULL,
	status INTEGER NOT NULL CHECK(status == 0 OR status == 1),
	FOREIGN KEY (id_user) REFERENCES user(id_user) ON DELETE CASCADE,
	FOREIGN KEY (id_achiev) REFERENCES achievement(id_achiev) ON DELETE CASCADE
);

CREATE TABLE "achiev_categ"
(
	id_categ INTEGER,
	id_achiev INTEGER,
	FOREIGN KEY (id_categ) REFERENCES category(id_categ),
	FOREIGN KEY (id_achiev) REFERENCES achievement(id_achiev)
);

CREATE TABLE "sched_task"
(
	id_sched INTEGER NOT NULL,
	id_task INTEGER NOT NULL,
	id_day INTEGER NOT NULL,
	FOREIGN KEY (id_sched) REFERENCES schedule(id_sched),
	FOREIGN KEY (id_task) REFERENCES task(id_task),
	FOREIGN KEY (id_day) REFERENCES day(id_day)
);

/* ----------------------- */

/* заполнение таблиц */

INSERT INTO day VALUES (NULL, "ПН");
INSERT INTO day VALUES (NULL, "ВТ");
INSERT INTO day VALUES (NULL, "СР");
INSERT INTO day VALUES (NULL, "ЧТ");
INSERT INTO day VALUES (NULL, "ПТ");
INSERT INTO day VALUES (NULL, "СБ");
INSERT INTO day VALUES (NULL, "ВС");

INSERT INTO user VALUES (NULL, NULL, "Rampad", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "1652");
INSERT INTO user VALUES (NULL, NULL, "Spike", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "6532");
INSERT INTO user VALUES (NULL, NULL, "Igenaric", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "1236");
INSERT INTO user VALUES (NULL, NULL, "Netris", "202CB962AC59075B964B07152D234B70", "email@mail.ru", "4672");

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

INSERT INTO data_service
VALUES
	(1, 4, "login", "password №1", "email@mail.ru");
INSERT INTO data_service
VALUES
	(2, 4, "login", "password №2", "0714148150");
INSERT INTO data_service
VALUES
	(3, 2, "login", "password №3", "email@mail.ru");
INSERT INTO data_service
VALUES
	(4, 3, "login", "password №4", "0714148150");
INSERT INTO data_service
VALUES
	(5, 4, "login", "password №5", "0714148150");

	INSERT INTO category
VALUES
	(NULL, "Без категории");
INSERT INTO category
VALUES
	(NULL, "Отношения");
INSERT INTO category
VALUES
	(NULL, "Работа");
INSERT INTO category
VALUES
	(NULL, "Бизнес");
INSERT INTO category
VALUES
	(NULL, "Саморазвитие");
INSERT INTO category
VALUES
	(NULL, "Учеба");
	
INSERT INTO direction
VALUES
	(NULL, 1, "Повседневные дела", "#323232");
INSERT INTO direction
VALUES
	(NULL, 2, "Работа", "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Мой бизнес", "#323232");
INSERT INTO direction
VALUES
	(NULL, 3, "Магазин 'Flora'", "#323232");
INSERT INTO direction
VALUES
	(NULL, 4, "Семья", "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Гитара", "#323232");
INSERT INTO direction
VALUES
	(NULL, 5, "Футбол", "#323232");

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
	
-- Без категории
INSERT INTO achievement VALUES (NULL, "Первый рубеж", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Нет предела совершенству", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Максимум усилий - максимум результата!", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Первый шаг", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Все по графику!", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "Вижу цель - не вижу препятствий", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "Герой выходного дня", "Выполнить задачу в выходные", 1);	
INSERT INTO achievement VALUES (NULL, "Целеустремленный", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "Целеустремленный", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "Целеустремленный", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "Целеустремленный", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "Целеустремленный", "Выполнить 100 задач", 100);	

-- Отношения
INSERT INTO achievement VALUES (NULL, "Лед тронулся", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Мастер отношений", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Гуру коммуникации", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Инициатор", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Пунктуальный", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "Сдержал обещание!", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "На сближение", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "На сближение", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "На сближение", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "На сближение", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "На сближение", "Выполнить 100 задач", 100);

-- Работа
INSERT INTO achievement VALUES (NULL, "То ли еще будет!", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Трудоголик", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Big BOSS", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Все под рукой", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Гроза дедлайнов", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "За трудовое отличие", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "Работник года", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "Работник года", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "Работник года", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "Работник года", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "Работник года", "Выполнить 100 задач", 100);

-- Бизнес
INSERT INTO achievement VALUES (NULL, "Хороший старт", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Гроза конкурентов", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Будущий монополист", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Главное - начать!", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Не время прохлаждаться", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "Максимальный КПД", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "Бизнесмен", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "Бизнесмен", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "Бизнесмен", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "Бизнесмен", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "Бизнесмен", "Выполнить 100 задач", 100);

-- Саморазвитие
INSERT INTO achievement VALUES (NULL, "Уже привычка", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Тотальный UPGRADE", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Новый “Я”", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Попытка не пытка", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Главное - регулярность", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "Выполнил и не заметил", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "Лучше чем вчера", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "Лучше чем вчера", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "Лучше чем вчера", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "Лучше чем вчера", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "Лучше чем вчера", "Выполнить 100 задач", 100);

-- Учеба
INSERT INTO achievement VALUES (NULL, "Гордость родителей", "Поднять эффективность до 50%", 50);
INSERT INTO achievement VALUES (NULL, "Прилежный ученик", "Поднять эффективность до 80%", 80);
INSERT INTO achievement VALUES (NULL, "Как тебе такое, Илон Маск?)", "Поднять эффективность до 100%", 100);
INSERT INTO achievement VALUES (NULL, "Первое ДЗ", "Создать задачу", 1);
INSERT INTO achievement VALUES (NULL, "Шаг за шагом", "Создать расписание", 1);
INSERT INTO achievement VALUES (NULL, "Пятерка гарантирована", "Выполнить все задачи за день", 1);	
INSERT INTO achievement VALUES (NULL, "Проще простого!", "Выполнить 1 задачу", 1);	
INSERT INTO achievement VALUES (NULL, "Проще простого!", "Выполнить 10 задач", 10);	
INSERT INTO achievement VALUES (NULL, "Проще простого!", "Выполнить 30 задач", 30);	
INSERT INTO achievement VALUES (NULL, "Проще простого!", "Выполнить 50 задач", 50);
INSERT INTO achievement VALUES (NULL, "Проще простого!", "Выполнить 100 задач", 100);

-- Без категории	
INSERT INTO achiev_categ VALUES (1, 1);
INSERT INTO achiev_categ VALUES (1, 2);
INSERT INTO achiev_categ VALUES (1, 3);
INSERT INTO achiev_categ VALUES (1, 4);
INSERT INTO achiev_categ VALUES (1, 5);
INSERT INTO achiev_categ VALUES (1, 6);
INSERT INTO achiev_categ VALUES (1, 7);
INSERT INTO achiev_categ VALUES (1, 8);
INSERT INTO achiev_categ VALUES (1, 9);
INSERT INTO achiev_categ VALUES (1, 10);
INSERT INTO achiev_categ VALUES (1, 11);
INSERT INTO achiev_categ VALUES (1, 12);

-- Отношения
INSERT INTO achiev_categ VALUES (2, 13);
INSERT INTO achiev_categ VALUES (2, 14);
INSERT INTO achiev_categ VALUES (2, 15);
INSERT INTO achiev_categ VALUES (2, 16);
INSERT INTO achiev_categ VALUES (2, 17);
INSERT INTO achiev_categ VALUES (2, 18);
INSERT INTO achiev_categ VALUES (2, 19);
INSERT INTO achiev_categ VALUES (2, 20);
INSERT INTO achiev_categ VALUES (2, 21);
INSERT INTO achiev_categ VALUES (2, 22);
INSERT INTO achiev_categ VALUES (2, 23);

-- Работа
INSERT INTO achiev_categ VALUES (3, 24);
INSERT INTO achiev_categ VALUES (3, 25);
INSERT INTO achiev_categ VALUES (3, 26);
INSERT INTO achiev_categ VALUES (3, 27);
INSERT INTO achiev_categ VALUES (3, 28);
INSERT INTO achiev_categ VALUES (3, 29);
INSERT INTO achiev_categ VALUES (3, 30);
INSERT INTO achiev_categ VALUES (3, 31);
INSERT INTO achiev_categ VALUES (3, 32);
INSERT INTO achiev_categ VALUES (3, 33);
INSERT INTO achiev_categ VALUES (3, 34);

-- Бизнес
INSERT INTO achiev_categ VALUES (4, 35);
INSERT INTO achiev_categ VALUES (4, 36);
INSERT INTO achiev_categ VALUES (4, 37);
INSERT INTO achiev_categ VALUES (4, 38);
INSERT INTO achiev_categ VALUES (4, 39);
INSERT INTO achiev_categ VALUES (4, 40);
INSERT INTO achiev_categ VALUES (4, 41);
INSERT INTO achiev_categ VALUES (4, 42);
INSERT INTO achiev_categ VALUES (4, 43);
INSERT INTO achiev_categ VALUES (4, 44);
INSERT INTO achiev_categ VALUES (4, 45);

-- Саморазвитие
INSERT INTO achiev_categ VALUES (5, 46);
INSERT INTO achiev_categ VALUES (5, 47);
INSERT INTO achiev_categ VALUES (5, 48);
INSERT INTO achiev_categ VALUES (5, 49);
INSERT INTO achiev_categ VALUES (5, 50);
INSERT INTO achiev_categ VALUES (5, 51);
INSERT INTO achiev_categ VALUES (5, 52);
INSERT INTO achiev_categ VALUES (5, 53);
INSERT INTO achiev_categ VALUES (5, 54);
INSERT INTO achiev_categ VALUES (5, 55);
INSERT INTO achiev_categ VALUES (5, 56);

-- Учеба
INSERT INTO achiev_categ VALUES (6, 57);
INSERT INTO achiev_categ VALUES (6, 58);
INSERT INTO achiev_categ VALUES (6, 59);
INSERT INTO achiev_categ VALUES (6, 60);
INSERT INTO achiev_categ VALUES (6, 61);
INSERT INTO achiev_categ VALUES (6, 62);
INSERT INTO achiev_categ VALUES (6, 63);
INSERT INTO achiev_categ VALUES (6, 64);
INSERT INTO achiev_categ VALUES (6, 65);
INSERT INTO achiev_categ VALUES (6, 66);
INSERT INTO achiev_categ VALUES (6, 67);

-- Достижения без категории - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 1, 5, 0);
INSERT INTO user_achiev VALUES (4, 2, 10, 0);
INSERT INTO user_achiev VALUES (4, 3, 15, 0);
INSERT INTO user_achiev VALUES (4, 4, 0, 1);
INSERT INTO user_achiev VALUES (4, 5, 0, 0);
INSERT INTO user_achiev VALUES (4, 6, 1, 1);
INSERT INTO user_achiev VALUES (4, 7, 0, 0);
INSERT INTO user_achiev VALUES (4, 8, 1, 1);
INSERT INTO user_achiev VALUES (4, 9, 1, 1);
INSERT INTO user_achiev VALUES (4, 10, 0, 0);
INSERT INTO user_achiev VALUES (4, 11, 1, 1);
INSERT INTO user_achiev VALUES (4, 12, 1, 1);

-- Достижения отношений - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 13, 5, 0);
INSERT INTO user_achiev VALUES (4, 14, 10, 0);
INSERT INTO user_achiev VALUES (4, 15, 15, 0);
INSERT INTO user_achiev VALUES (4, 16, 0, 0);
INSERT INTO user_achiev VALUES (4, 17, 1, 1);
INSERT INTO user_achiev VALUES (4, 18, 0, 0);
INSERT INTO user_achiev VALUES (4, 19, 1, 1);
INSERT INTO user_achiev VALUES (4, 20, 1, 1);
INSERT INTO user_achiev VALUES (4, 21, 0, 0);
INSERT INTO user_achiev VALUES (4, 22, 1, 1);
INSERT INTO user_achiev VALUES (4, 23, 1, 1);

-- Достижения работы - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 24, 5, 0);
INSERT INTO user_achiev VALUES (4, 25, 10, 0);
INSERT INTO user_achiev VALUES (4, 26, 15, 0);
INSERT INTO user_achiev VALUES (4, 27, 0, 0);
INSERT INTO user_achiev VALUES (4, 28, 1, 1);
INSERT INTO user_achiev VALUES (4, 29, 0, 0);
INSERT INTO user_achiev VALUES (4, 30, 1, 1);
INSERT INTO user_achiev VALUES (4, 31, 1, 1);
INSERT INTO user_achiev VALUES (4, 32, 0, 0);
INSERT INTO user_achiev VALUES (4, 33, 1, 1);
INSERT INTO user_achiev VALUES (4, 34, 100, 1);

-- Достижения бизнеса - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 35, 5, 0);
INSERT INTO user_achiev VALUES (4, 36, 10, 0);
INSERT INTO user_achiev VALUES (4, 37, 15, 0);
INSERT INTO user_achiev VALUES (4, 38, 0, 0);
INSERT INTO user_achiev VALUES (4, 39, 1, 1);
INSERT INTO user_achiev VALUES (4, 40, 0, 0);
INSERT INTO user_achiev VALUES (4, 41, 1, 1);
INSERT INTO user_achiev VALUES (4, 42, 1, 1);
INSERT INTO user_achiev VALUES (4, 43, 0, 0);
INSERT INTO user_achiev VALUES (4, 44, 1, 1);
INSERT INTO user_achiev VALUES (4, 45, 1, 1);

-- Достижения саморазвития - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 46, 5, 0);
INSERT INTO user_achiev VALUES (4, 47, 10, 0);
INSERT INTO user_achiev VALUES (4, 48, 15, 0);
INSERT INTO user_achiev VALUES (4, 49, 0, 0);
INSERT INTO user_achiev VALUES (4, 50, 1, 1);
INSERT INTO user_achiev VALUES (4, 51, 0, 0);
INSERT INTO user_achiev VALUES (4, 52, 1, 1);
INSERT INTO user_achiev VALUES (4, 53, 1, 1);
INSERT INTO user_achiev VALUES (4, 54, 0, 0);
INSERT INTO user_achiev VALUES (4, 55, 1, 1);
INSERT INTO user_achiev VALUES (4, 56, 1, 1);

-- Достижения саморазвития - 4ый пользователь
INSERT INTO user_achiev VALUES (4, 57, 5, 0);
INSERT INTO user_achiev VALUES (4, 58, 10, 0);
INSERT INTO user_achiev VALUES (4, 59, 15, 0);
INSERT INTO user_achiev VALUES (4, 60, 0, 0);
INSERT INTO user_achiev VALUES (4, 61, 1, 1);
INSERT INTO user_achiev VALUES (4, 62, 0, 0);
INSERT INTO user_achiev VALUES (4, 63, 1, 1);
INSERT INTO user_achiev VALUES (4, 64, 1, 1);
INSERT INTO user_achiev VALUES (4, 65, 0, 0);
INSERT INTO user_achiev VALUES (4, 66, 1, 1);
INSERT INTO user_achiev VALUES (4, 67, 1, 1);

INSERT INTO target
VALUES
	(NULL, 1, "Сделать ремонт");
INSERT INTO target
VALUES
	(NULL, 1, "Утеплить окна");
INSERT INTO target
VALUES
	(NULL, 2, "Перевыполнить план");
INSERT INTO target
VALUES
	(NULL, 2, "Повысить охват рекламы");
INSERT INTO target
VALUES
	(NULL, 2, "Разработать систему скидок");

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

	




