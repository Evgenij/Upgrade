SELECT count(id_task) FROM task 
INNER JOIN target ON target.id_target = task.id_target
INNER JOIN direction ON direction.id_direct = target.id_direct
INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct
WHERE user_dir.id_user = 3 AND task.date = "12.07.2020" AND task.status = 0