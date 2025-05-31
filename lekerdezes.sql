-- másfél óránál (5400sec) rövidebb speedrunokat megkeresi
SELECT runner, ido, category 
FROM speedrun 
WHERE ido < 5400;

-- 3 leggyorsabb speedrun '70star' kategóriában, növekvő sorrendbe.
SELECT runner, ido, category 
FROM speedrun 
WHERE category = '70star'
ORDER BY ido ASC
LIMIT 3;

--Kiadja mennyi speedrun van a kategóriákban, amit runok_szama néven mentünk le
SELECT category, COUNT(*) AS runok_szama
FROM speedrun
GROUP BY category;

--Frissíti a speedrun táblába lévő nevet a "Gusztávó" megadott névre, a megadott runnerid helyén, ami most "2"es runnerid
UPDATE speedrun 
SET runner = 'Gusztávó' 
WHERE runnerid = 2;

--törli azokat akik top 15 place alatt vannak
DELETE FROM speedrun 
WHERE place > 15;