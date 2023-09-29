#!/bin/bash

# Install MySql commands
# https://www.digitalocean.com/community/tutorials/how-to-install-mysql-on-ubuntu-20-04
sudo apt update
sudo apt install -y mysql-server
sudo service mysql start
sudo mysql_secure_installation

sudo mysql -u root -p -e "CREATE USER 'leetcode'@'localhost' IDENTIFIED BY 'vscode123'; GRANT ALL PRIVILEGES ON *.* TO 'leetcode'@'localhost' WITH GRANT OPTION; FLUSH PRIVILEGES;"
# mysql> CREATE USER 'leetcode'@'localhost' IDENTIFIED BY 'vscode123';
# mysql> GRANT ALL PRIVILEGES ON *.* TO 'leetcode'@'localhost' WITH GRANT OPTION;
# mysql> FLUSH PRIVILEGES;
# mysql> exit
sudo mysql -u leetcode -p -e "CREATE DATABASE leetcode DEFAULT CHARACTER SET = 'utf8mb4'"