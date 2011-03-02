@echo off
mysql --user=root -p < "OpenEHS Database Full Script.sql"
mysql --user=root -p < "OpenEHS_TestData Script.sql"
echo Finished!
