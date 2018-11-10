#!/usr/bin/python3
import pymysql

from nltk.corpus import stopwords
# Open database connection
db = pymysql.connect("localhost","root","password","girrafe" )

# prepare a cursor object using cursor() method
cursor = db.cursor()


def filterOutCommonWords(input) :
    s=set(stopwords.words('english'))
    
    return "|".join(filter(lambda w:not w in s, input.split()))
    #return list(filter(lambda w:not w in s, input.split()))

#def mergeWords()

# insert to table
def insert(answer):
    sql = """INSERT INTO ANSWER(ANSWER) VALUES ('"""+ answer + """')"""
    try:
        # Execute the SQL command
        cursor.execute(sql)
        # Commit your changes in the database
        db.commit()
    except:
        # Rollback in case there is any error
        db.rollback()


def search2(input):
    sql = 'SELECT * FROM answers WHERE answers REGEXP "' + input + '"'
    cursor.execute(sql)
    try:
        # Execute the SQL command
        cursor.execute(sql)
        # Fetch all the rows in a list of lists.
        results = cursor.fetchall()
        for row in results:
            answers = row[0]
            # Now print fetched result
            print ("asnwer = %s" % \
                   (answers))
    except:
        print ("Error: unable to fetch data")


def search(input):
    sql = 'SELECT * FROM answers WHERE answers LIKE "%' + input + '%" LIMIT 1'
    cursor.execute(sql)
    try:
        # Execute the SQL command
        cursor.execute(sql)
        # Fetch all the rows in a list of lists.
        results = cursor.fetchall()
        for row in results:
            answers = row[0]
            # Now print fetched result
            print ("asnwer = %s" % \
                   (answers))
    except:
        print ("Error: unable to fetch data")


input_term = "headache at night"
output = filterOutCommonWords(input_term)
print(output)

search2(output)

# =============================================================================
# 
# # Prepare SQL query to INSERT a record into the database.
# sql = "SELECT * FROM employee \
#         "
# 
# try:
#    # Execute the SQL command
#    cursor.execute(sql)
#    # Fetch all the rows in a list of lists.
#    results = cursor.fetchall()
#    for row in results:
#       answers = row[0]
#       # Now print fetched result
#       print ("asnwer = %s" % \
#          (answers))
# except:
#    print ("Error: unable to fetch data")
# 
# =============================================================================
# disconnect from server
db.close()
