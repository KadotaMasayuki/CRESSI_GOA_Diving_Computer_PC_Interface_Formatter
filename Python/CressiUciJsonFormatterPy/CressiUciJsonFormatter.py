#-------------------------------------------------------------------------------
# Name:        CRESSI-UCI-JSON-FORMATTER
# Purpose:     Format CRESSI Dive Computer's JSON Log to TSV
#
# Author:      kadota masayuki
#
# Created:     15/02/2022
# Copyright:   (c) kadota masayuki 2022
# Licence:     <your licence>
#-------------------------------------------------------------------------------


import json


def main():
    f = open("CressiUCI.json")
    j =json.load(f)
    rslt1 = []
    for dive in j['FreeDive']:
        #filePrint("FreeDive / " + fd['ID'] + "/" + e['ProgressiveNumber'] + "/" + e['DiveStart'])
        dive_id = dive['ID']
        dive_dt = dive['DiveStart']
        dive_dt = dive_dt[6:10] + "/" + dive_dt[3:5] + "/" + dive_dt[0:2] + " " + dive_dt[11:]
        dive_depth = []
        for dive_profile in j['FreeProfilePoint']:
            if (dive_profile['ID_FreeDive'] == dive_id):
                dive_depth.append(dive_profile['Depth'])
        l = []
        l.extend(["FreeDive", dive_id, dive_dt])
        l.extend(dive_depth)
        #l.extend(["END"])
        rslt1.append(l)
    for dive in j['ScubaDive']:
        #filePrint("ScubaDive / " + e['ID'] + "/" + e['ProgressiveNumber'] + "/" + e['DiveStart'])
        dive_id = dive['ID']
        dive_dt = dive['DiveStart']
        dive_dt = dive_dt[6:10] + "/" + dive_dt[3:5] + "/" + dive_dt[0:2] + " " + dive_dt[11:]
        dive_depth = []
        for dive_profile in j['ScubaProfilePoint']:
            if (dive_profile['ID_ScubaDive'] == dive_id):
                dive_depth.append(dive_profile['Depth'])
        l = []
        l.extend(["ScubaDive", dive_id, dive_dt])
        l.extend(dive_depth)
        #l.extend(["END"])
        rslt1.append(l)
    # caluclate array size
    rows = 0
    cols = len(rslt1)
    for r in rslt1:
        if (len(r) > rows):
            rows = len(r)
    # rearrange new array
    rslt2 = [[''] * cols for i in range(rows)]
    for c in range(len(rslt1)):
        for r in range(len(rslt1[c])):
            rslt2[r][c] = rslt1[c][r]
    # create string
    rslt3 = []
    for l in rslt2:
        rslt3.append("\t".join(l))
    rslt4 = "\n".join(rslt3)
    filePrint(rslt4)


def filePrint(str):
    outfile = open("out.txt",mode='w')
    print(str, file=outfile)
    #print(str)

if __name__ == '__main__':
    main()
