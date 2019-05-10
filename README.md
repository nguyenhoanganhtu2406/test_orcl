# Test Oracle
Create Database:

1. Run create_user_banhang.sql. If this error occurs: <code> ORA-65096: invalid common user or role name in oracle. </code>
Following these steps:

 <code> sqlplus as username/password@host:port/SID </code>
 
 
 <code> alter session set "_ORACLE_SCRIPT"=true; </code>
 
 
2. Add new connection and Log in as nva
3. Run db_banhang_v2.sql
