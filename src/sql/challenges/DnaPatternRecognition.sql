
/* https://leetcode.com/problems/dna-pattern-recognition */

CREATE TABLE if not exists Samples (
    sample_id INT,
    dna_sequence VARCHAR(255),
    species VARCHAR(100)
)
Truncate table Samples
insert into Samples (sample_id, dna_sequence, species) values ('1', 'ATGCTAGCTAGCTAA', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('2', 'GGGTCAATCATC', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('3', 'ATATATCGTAGCTA', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('4', 'ATGGGGTCATCATAA', 'Mouse')
insert into Samples (sample_id, dna_sequence, species) values ('5', 'TCAGTCAGTCAG', 'Mouse')
insert into Samples (sample_id, dna_sequence, species) values ('6', 'ATATCGCGCTAG', 'Zebrafish')
insert into Samples (sample_id, dna_sequence, species) values ('7', 'CGTATGCGTCGTA', 'Zebrafish')

# Write your MySQL query statement below

SELECT
    *,
    CASE WHEN dna_sequence LIKE 'ATG%' THEN 1 ELSE 0 END AS has_start,
    CASE WHEN dna_sequence REGEXP 'TAA$|TAG$|TGA$' THEN 1 ELSE 0 END AS has_stop,
    CASE WHEN dna_sequence LIKE '%ATAT%' THEN 1 ELSE 0 END AS has_atat,
    CASE WHEN dna_sequence LIKE '%GGG%' THEN 1 ELSE 0 END AS has_ggg
FROM Samples

---

SELECT
    *,
    IF(dna_sequence LIKE 'ATG%', 1, 0) AS has_start,
    IF(dna_sequence REGEXP 'TAA$|TAG$|TGA$', 1, 0) AS has_stop,
    IF(dna_sequence LIKE '%ATAT%', 1, 0) AS has_atat,
    IF(dna_sequence LIKE '%GGG%', 1, 0) AS has_ggg
FROM Samples

/*MSSQL*/

SELECT
    *,
    IIF(dna_sequence LIKE 'ATG%', 1, 0) AS has_start,
    IIF(dna_sequence LIKE '%TAA' OR dna_sequence LIKE '%TAG' OR dna_sequence LIKE '%TGA', 1, 0) AS has_stop,
    IIF(dna_sequence LIKE '%ATAT%', 1, 0) AS has_atat,
    IIF(dna_sequence LIKE '%GGG%', 1, 0) AS has_ggg
FROM Samples

/*
Test Cases
{"headers":{"Samples":["sample_id","dna_sequence","species"]},"rows":{"Samples":[[1,"ATGCTAGCTAGCTAA","Human"],[2,"GGGTCAATCATC","Human"],[3,"ATATATCGTAGCTA","Human"],[4,"ATGGGGTCATCATAA","Mouse"],[5,"TCAGTCAGTCAG","Mouse"],[6,"ATATCGCGCTAG","Zebrafish"],[7,"CGTATGCGTCGTA","Zebrafish"]]}}
*/
