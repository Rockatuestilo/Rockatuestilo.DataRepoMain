-- Step 1: Drop the view `tb_news` if it exists
DROP VIEW IF EXISTS tb_news;

-- Step 2: Drop the current `Articles` table
DROP TABLE IF EXISTS Articles;

-- Step 3: Restore `tb_news` from the backup
RENAME TABLE tb_news_backup TO tb_news;

-- Step 4: Restore `Articles` from the backup
RENAME TABLE articles_backup TO Articles;
