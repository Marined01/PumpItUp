
if [ -f .env ]; then
  while IFS= read -r line || [ -n "$line" ]; do
    if [[ ! "$line" =~ ^# && "$line" =~ = ]]; then
      export "$line"
    fi
  done < .env
else

  echo ".env файл не знайдений!"
  exit 1
fi

if [ ! -d "migrations" ]; then
  echo "Директорія міграцій не знайдена!"
  exit 1
fi

if [ -z "$DB_HOST" ] || [ -z "$DB_PORT" ] || [ -z "$DB_NAME" ] || [ -z "$DB_USER" ] || [ -z "$DB_PASSWORD" ]; then
  echo "Необхідно вказати змінні середовища для DB_HOST, DB_PORT, DB_NAME, DB_USER, DB_PASSWORD"
  exit 1
fi

export PGPASSWORD=$DB_PASSWORD

for migration in migrations/*.sql
do
  echo "Застосування міграції: $migration"
  psql -h $DB_HOST -U $DB_USER -d $DB_NAME -a -f "$migration"
done

unset PGPASSWORD
