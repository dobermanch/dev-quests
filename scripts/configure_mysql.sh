#!/bin/bash

# Install MySql commands
# https://www.digitalocean.com/community/tutorials/how-to-install-mysql-on-ubuntu-20-04

echo "==="
echo "  Configure MySQL"
echo "==="

sudo apt update
sudo apt install -y mysql-server
sudo service mysql start
# sudo mysql_secure_installation

#sudo mysql -e "UPDATE mysql.user SET Password=PASSWORD('root') WHERE User='root'"
# sudo mysql -e "DELETE FROM mysql.user WHERE User=''"
# sudo mysql -e "DELETE FROM mysql.user WHERE User='root' AND Host NOT IN ('localhost', '127.0.0.1', '::1')"
# sudo mysql -e "DROP DATABASE IF EXISTS test"
# sudo mysql -e "DELETE FROM mysql.db WHERE Db='test' OR Db='test\\_%'"
# sudo mysql -e "FLUSH PRIVILEGES"

sudo mysql -e "CREATE USER 'leetcode'@'localhost' IDENTIFIED BY 'vscode123'; GRANT ALL PRIVILEGES ON *.* TO 'leetcode'@'localhost' WITH GRANT OPTION; FLUSH PRIVILEGES;"
# # mysql> CREATE USER 'leetcode'@'localhost' IDENTIFIED BY 'vscode123';
# # mysql> GRANT ALL PRIVILEGES ON *.* TO 'leetcode'@'localhost' WITH GRANT OPTION;
# # mysql> FLUSH PRIVILEGES;
# # mysql> exit
sudo mysql -u leetcode -pvscode123 -e "CREATE DATABASE leetcode DEFAULT CHARACTER SET = 'utf8mb4'"