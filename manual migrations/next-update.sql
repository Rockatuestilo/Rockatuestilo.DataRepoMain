-- Step 1: Drop the existing `Articles` table if it exists (safety precaution)
DROP TABLE IF EXISTS Articles;

-- Step 2: Rename `tb_news` to `Articles`
RENAME TABLE tb_news TO Articles;

-- Step 3: Create a view `tb_news` for backward compatibility
CREATE VIEW tb_news AS
SELECT *
FROM Articles;
