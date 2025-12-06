# Database

## Core Concepts in Database Design

1. Data Models

- Relational Model: Tables, rows, and columns with predefined schemas (e.g., PostgreSQL, MySQL).
- Document Model: JSON-like storage, good for hierarchical data (e.g., MongoDB).
- Key-Value Model: High-speed lookups; think Redis or DynamoDB.
- Column-Family Model: Optimized for wide tables and analytical workloads (e.g., Cassandra).
- Graph Model: Nodes and edges; great for social networks or recommendation engines (e.g., Neo4j).

2. Schema Design

- Normalization: Reduce redundancy; split data into related tables.
- Denormalization: For performance at scale—trade-offs accepted in distributed environments.
- Indexes: Speed up queries; types include B-Tree, Hash, GiST, GIN.

3. Transactions and ACID

- Atomicity: All-or-nothing.
- Consistency: Valid state transitions.
- Isolation: Operations don’t interfere.
- Durability: Changes survive failures.

4. Query Processing

- SQL vs NoSQL: Structured querying vs flexible data access.
- Execution Plans: Understand how a query is processed under the hood.
- Joins & Aggregations: Combining data sources and performing operations across them.

5. Storage Engines

- Write-Ahead Logging (WAL): Ensures durability before applying changes.
- LSM Trees vs B-Trees: Trade-offs in write-heavy vs read-heavy workloads.

6. Replication & Sharding

- Replication: Copies of data for high availability (leader-follower, multi-leader).
- Sharding: Data partitioning for horizontal scalability.

---

## 🧱 Foundations of Relational Databases

1. Tables and Relations

- Data is organized into tables (aka relations), each representing an entity (e.g., Customers, Orders).
- Each table has rows (records) and columns (attributes), enforcing a clear schema.

2. Primary Keys

- Each table should have a primary key: a unique identifier for each row.
- Composite keys are allowed but can become unwieldy in practice unless tightly coupled domains justify them.

3. Foreign Keys

- A foreign key creates a relationship between two tables (e.g., Orders.CustomerID references Customers.ID).
- Enables referential integrity, ensuring that relationships between tables remain valid.

4. Normalization

- Process of organizing data to reduce redundancy and improve data integrity.
- Follows multiple normal forms:
- 1NF: Eliminate repeating groups
- 2NF: Remove partial dependencies
- 3NF: Remove transitive dependencies
- While normalized schemas aid in maintainability, denormalization may be necessary for performance optimization, especially in distributed systems.

5. Joins

- Combine rows from two or more tables based on related columns:
- INNER JOIN: Matches records in both tables
- LEFT/RIGHT JOIN: Includes all records from one side
- OUTER JOIN: Combines matched and unmatched records

6. Transactions & ACID Properties

Relational databases support transactional operations with ACID guarantees:

- Atomicity: All operations succeed or fail as one
- Consistency: Transactions move the DB from one valid state to another
- Isolation: Concurrent transactions don’t interfere
- Durability: Completed transactions persist across failures

7. Indexes

- Speed up data retrieval at the cost of write performance and storage.
- Types include:
- B-Tree Indexes: Default for ordered data
- Hash Indexes: Great for equality lookups
- Composite Indexes: Span multiple columns

---

## 🧱 Relational Database Essentials

💡 What Makes a DB "Relational"?

- Based on E.F. Codd's relational model: data is stored in tables (relations) consisting of rows (tuples) and columns (attributes).
- Uses keys to define relationships:
- Primary key: uniquely identifies a record.
- Foreign key: establishes integrity across tables.

🧮 Schema & Data Integrity

- Strict schema enforcement means each column has a type (e.g., INT, VARCHAR, DATE).
- Enforces constraints:
  - NOT NULL, UNIQUE, CHECK, DEFAULT, FOREIGN KEY, PRIMARY KEY
- Normalization aims to:
  - Reduce redundancy
  - Avoid update anomalies
  - Improve logical consistency

🔁 Transaction Mechanics

- Backed by ACID properties, which you likely optimize via consistency levels and isolation guarantees:
- Atomicity: all operations succeed or fail together
- Consistency: maintains validity across transactions
- Isolation: concurrency control (more below!)
- Durability: persisted even on crash

📊 Query Power & Indexing

- SQL for data manipulation (SELECT, INSERT, UPDATE, DELETE)
- Joins allow cross-table operations:
  - INNER, LEFT, RIGHT, FULL OUTER, CROSS
- Index types:
- B-tree: standard and performant for ordered scans
- Hash: fast lookups, not range friendly
- GIN/GiST: flexible for full-text or spatial queries

🔒 Isolation Levels (the fun part!)

- READ UNCOMMITTED: dirty reads allowed
- READ COMMITTED: default for most; no dirty reads
- REPEATABLE READ: avoids non-repeatable reads
- SERIALIZABLE: strictest; full isolation but risk of contention

---

## 📐 Database Normalization Forms

🧩 1NF – First Normal Form

- Ensures atomicity of values: every cell contains a single value (no arrays or comma-separated lists).
- Each row must be unique, and order of rows and columns doesn’t matter.
- 🚫 Repeating groups? Time to break those into separate rows or tables.

🔗 2NF – Second Normal Form

- Builds on 1NF.
- Requires that every non-key attribute is fully dependent on the whole primary key.
- Fixes partial dependencies, especially important in tables with composite keys.
- Example: If a table has (StudentID, CourseID) as a composite PK, and StudentName depends only on StudentID, it’s violating 2NF.

🔄 3NF – Third Normal Form

- Builds on 2NF.
- Removes transitive dependencies: non-key attributes should not depend on other non-key attributes.
- Classic fix: Move DepartmentLocation out of the Employees table into a Departments table.

🧠 BCNF – Boyce-Codd Normal Form

- A stricter version of 3NF.
- Every determinant must be a candidate key.
- Helps when there are multiple candidate keys and anomalies still sneak in.

🧵 4NF – Fourth Normal Form

- Tackles multi-valued dependencies.
- If two or more independent facts belong to the same key, break them apart.
- Example: An Artist might have multiple Genres and multiple Instruments. These should not be stored in a single table.

🗃️ 5NF – Fifth Normal Form (Project-Join Normal Form)

- Splits data into the smallest pieces where all data is reconstructible via joins.
- Prevents anomalies in scenarios with complex joins across decomposed relations.

🧩 6NF – Sixth Normal Form (rarely used)

- Each fact is represented with temporal support—useful in systems with time-varying data like audits or historical records.

---

## 🏗️ What Is Denormalization?

- The intentional introduction of redundancy into a database schema.
- Used to avoid complex joins, reduce latency, and optimize read-heavy workloads.
- Particularly useful in:
  - High-traffic web applications
  - CQRS read models
  - Analytics/OLAP systems
  - Edge or offline-ready databases

🔧 Common Denormalization Patterns
| Pattern | Description | Use Case |
| Embedded Values | Store related data directly in one row | Combine Customer name in Orders |
| Precomputed Aggregates | Save rollups or summaries | Track TotalSales in Customer |
| Materialized Views | Store the result of a query as a static table | Used in PostgreSQL or BigQuery |
| Join Tables Flattened | Merge multi-table relationships into one | Combine Products, Category, and Vendor into a single table |

⚖️ Pros & Trade-offs

✅ Pros

- Fast reads
- Simple query logic
- Reduced network round-trips

⚠️ Cons

- Data duplication
- Update anomalies
- Heavier write operations
- Schema drift over time

In distributed systems, these trade-offs are magnified by replication lag, consistency models, and eventual convergence. That’s why denormalization is often paired with immutable data models, event sourcing, or materialized projections.

---

