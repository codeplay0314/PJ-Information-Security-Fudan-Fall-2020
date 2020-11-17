#include <windows.h>
#include <bits/stdc++.h>
using namespace std;

namespace DES {
    typedef bitset<64> BITS64;
    typedef bitset<56> BITS56;
    typedef bitset<48> BITS48;
    typedef bitset<32> BITS32;
    typedef bitset<28> BITS28;

    const int IP[] = {
        58, 50, 42, 34, 26, 18, 10, 2,
    	60, 52, 44, 36, 28, 20, 12, 4,
		62, 54, 46, 38, 30, 22, 14, 6,
		64, 56, 48, 40, 32, 24, 16, 8,
		57, 49, 41, 33, 25, 17, 9, 1,
		59, 51, 43, 35, 27, 19, 11, 3,
		61, 53, 45, 37, 29, 21, 13, 5,
		63, 55, 47, 39, 31, 23, 15, 7},
    IP_1[] = {
        40, 8, 48, 16, 56, 24, 64, 32,
	    39, 7, 47, 15, 55, 23, 63, 31,
	    38, 6, 46, 14, 54, 22, 62, 30,
	    37, 5, 45, 13, 53, 21, 61, 29,
	    36, 4, 44, 12, 52, 20, 60, 28,
	    35, 3, 43, 11, 51, 19, 59, 27,
	    34, 2, 42, 10, 50, 18, 58, 26,
	    33, 1, 41, 9, 49, 17, 57, 25},
    PC_1[] =  {
        57, 49, 41, 33, 25, 17, 9,
        1, 58, 50, 42, 34, 26, 18,
        10, 2, 59, 51, 43, 35, 27,
        19, 11, 3, 60, 52, 44, 36,
        63, 55, 47, 39, 31, 23, 15,
        7, 62, 54, 46, 38, 30, 22,
        14, 6, 61, 53, 45, 37, 29,
        21, 13, 5, 28, 20, 12, 4},
   PC_2[] = {
        14, 17, 11, 24, 1, 5,
        3, 28, 15, 6, 21, 10,
        23, 19, 12, 4, 26, 8,
        16, 7, 27, 20, 13, 2,
        41, 52, 31, 37, 47, 55,
        30, 40, 51, 45, 33, 48,
        44, 49, 39, 56, 34, 53,
        46, 42, 50, 36, 29, 32},
    shift[] = {1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1},
    E[] = {
        32, 1, 2, 3, 4, 5,
        4, 5, 6, 7, 8, 9,
        8, 9, 10, 11, 12, 13,
        12, 13, 14, 15, 16, 17,
        16, 17, 18, 19, 20, 21,
        20, 21, 22, 23, 24, 25,
        24, 25, 26, 27, 28, 29,
        28, 29, 30, 31, 32, 1},
    S_BOX[8][4][16] = { {
            {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
            {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
            {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
            {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}
        }, {
    		{15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
    		{3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
    		{0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
    		{13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}
    	}, {
    		{10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
    		{13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
    		{13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
    		{1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
    	}, {
    		{7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
    		{13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
    		{10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
    		{3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
    	}, {
    		{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
    		{14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
    		{4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
    		{11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}
    	}, {
    		{12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
    		{10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
    		{9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
    		{4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}
    	}, {
    		{4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
    		{13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
    		{1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
    		{6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}
    	}, {
    		{13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
    		{1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
    		{7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
    		{2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
    	}
    },
    P[] = {
        16, 7, 20, 21,
        29, 12, 28, 17,
        1, 15, 23, 26,
        5, 18, 31, 10,
        2, 8, 24, 14,
        32, 27, 3, 9,
        19, 13, 30, 6,
        22, 11, 4, 25
    };


    const int maxl = 1024;
    int len;
    bool text[maxl], to[maxl], pre[maxl];
    BITS64 key;
    BITS48 subKey[16];

    BITS32 f(BITS32 R, BITS48 K) {
    	BITS48 ex = K;
    	BITS32 res, tmp;
    	for (int i = 0; i < 48; i++) ex[47 - i] = ex[47 - i] ^ R[32 - E[i]];
    	for (int i = 0, x = 0; i < 48; i += 6, x += 4) {
    		bitset<4> bi(S_BOX[i / 6][ex[47 - i] * 2 + ex[47 - i - 5]][ex[47 - i - 1] * 8 + ex[47 - i - 2] * 4 + ex[47 - i - 3] * 2 + ex[47 - i - 4]]);
            for (int j = 0; j < 4; j++) res[32 - x - j] = bi[3 - j];
    	}
    	tmp = res;
    	for (int i = 0; i < 32; i++) res[31 - i] = tmp[32 - P[i]];
    	return res;
    }

    void Shift(BITS28 &k, int t) {
    	BITS28 res;
        for (int i = 0; i < 28; i++) res[i] = k[(i + t) % 28];
    	k = res;
    }

    void generateKeys() {
    	BITS56 Key;
    	BITS28 left, right;
    	BITS48 compressKey;
    	for (int i = 0; i < 56; i++) Key[55 - i] = key[64 - PC_1[i]];
    	for (int r = 0; r < 16; r++) {
    		for (int i = 28; i < 56; i++) left[i - 28] = Key[i];
    		for (int i = 0; i < 28; i++) right[i] = Key[i];
    		Shift(left, shift[r]), Shift(right, shift[r]);
    		for (int i = 28; i < 56; i++) Key[i] = left[i - 28];
    		for (int i = 0; i < 28; i++) Key[i] = right[i];
    		for (int i = 0; i < 48; i++) subKey[r][47 - i] = Key[56 - PC_2[i]];
    	}
    }

    BITS64 encrypt(BITS64 plain) {
    	BITS64 res, cur;
    	BITS32 left, right;
    	for (int i = 0; i < 64; i++) cur[63 - i] = plain[64 - IP[i]];
    	for (int i = 32; i < 64; i++) left[i - 32] = cur[i];
    	for (int i = 0; i < 32; i++) right[i] = cur[i];
    	for (int r = 0; r < 16; r++) {
    		BITS32 tmp = right;
    		right = left ^ f(right, subKey[r]);
    		left = tmp;
    	}
    	for (int i = 0; i < 32; i++) res[i] = left[i];
    	for (int i = 32; i < 64; i++) res[i] = right[i - 32];
    	cur = res;
    	for (int i = 0; i < 64; i++) res[63 - i] = cur[64 - IP_1[i]];
    	return res;
    }

    BITS64 decrypt(BITS64 ori) {
    	BITS64 res, cur;
    	BITS32 left, right;
    	for (int i = 0; i < 64; i++) cur[63 - i] = ori[64 - IP[i]];
    	for (int i = 32; i < 64; i++) left[i - 32] = cur[i];
    	for (int i = 0; i < 32; i++) right[i] = cur[i];
    	for (int r = 0; r < 16; r++) {
    		BITS32 tmp = right;
    		right = left ^ f(right, subKey[16 - r - 1]);
    		left = tmp;
    	}
    	for (int i = 0; i < 32; i++) res[i] = left[i];
    	for (int i = 32; i < 64; i++) res[i] = right[i - 32];
    	cur = res;
    	for (int i = 0; i < 64; i++) res[63 - i] = cur[64 - IP_1[i]];
    	return res;
    }

    void Encode() {
        int k = len % 64, st = len - k, res = 64 - k;
        if (res != 64) {
            if (res >= 6) {
                len += res;
                res -= 6;
                for (int i = 0; i < 6; i++)
                    text[st + 58 + i] = res & 1, res >>= 1;
            } else {
                len += res + 64;
                res -= 6;
                for (int i = 0; i < 6; i++)
                    text[st + 122 + i] = res & 1, res >>= 1;
            }
        } else {
            len += 64;
            res -= 6;
            for (int i = 0; i < 6; i++)
                text[st + 58 + i] = res & 1, res >>= 1;
        }
# ifdef DEBUG
        for (int i = 0; i < len; i++) printf("%d", text[i]);
        putchar('\n');
# endif
        generateKeys();
        BITS64 s, t;
        for (int i = 0; i < len; i += 64) {
            for (int j = 0; j < 64; j++) s[j] = text[i + j]^pre[j];
            t = encrypt(s);
            for (int j = 0; j < 64; j++) pre[j] = to[i + j] = t[j];
        }
    }

    void Decode() {
        generateKeys();
        BITS64 s, t;
        bool tmp[64];
        for (int i = 0; i < len; i += 64) {
            for (int j = 0; j < 64; j++) s[j] = text[i + j];
            t = decrypt(s);
            memcpy(tmp, text + i, 64);
            for (int j = 0; j < 64; j++) to[i + j] = t[j]^pre[j];
            memcpy(pre, tmp, 64);
        }
        int l = 0;
        for (int i = 0; i < 6; i++)
            l = l * 2 + to[len - i - 1];
# ifdef DEBUG
        for (int i = 0; i < len; i++) printf("%d", to[i]);
        putchar('\n');
        printf("%d\n", len);
# endif
        len -= l + 6;
    }
    void out(FILE *f) {
        for (int i = 0; i < len; i++) fprintf(f, "%d", to[i]);
    }
}

void decodeRSA(string str, char *s) {
    FILE* fp = NULL;
    char cmd[50];
    str = "python RSA/decode.py " + str;
    strcpy(cmd, str.c_str());
    if (fp = popen(cmd, "r")) {
        fgets(s, 65, fp);
        pclose(fp);
    }
}

int main(int argc, char *argv[]) {
    int kase;
    char s[100];
    FILE *f1 = NULL, *f2 = NULL;
    while (true) {
        while (true) {
            system("cls");
            printf("Please Select:\n1. Encode\n2. Decode\n0. Exit\n");
            scanf("%d", &kase);
            if (kase == 0) {
                system("cls");
                printf("Successfully exit!\n");
                Sleep(2000);
                return 0;
            }
            if (0 <= kase && kase <= 2) break;
            printf("Please enter again!\n");
            Sleep(2000);
        }
        while (true) {
            system("cls");
            printf("%s\n", kase == 1? " - - -  Encoding - - -  ": " - - -  Decoding - - - ");
            printf("Please enter the key (RSA encoded): ");
            string codedS;
            cin >> codedS;
            decodeRSA(codedS, s);
            bool check = true;
            int n = strlen(s);
            if (n != 64) check = false;
            for (int i = 0; i < 64 && check; i++)
                if (s[i] != '0' && s[i] != '1') check = false;
            if (check) {
                for (int i = 0; i < 64; i++) DES::key[i] = s[i] == '1'? 1: 0;
                break;
            }
            printf("Please enter valid key!\n");
            Sleep(2000);
        }
        while (true) {
            system("cls");
            printf("%s\n", kase == 1? " - - -  Encoding - - -  ": " - - -  Decoding - - - ");
            printf("Please enter initial vector (RSA encoded): ");
            string codedS;
            cin >> codedS;
            decodeRSA(codedS, s);
            bool check = true;
            int n = strlen(s);
            if (n != 64) check = false;
            for (int i = 0; i < 64 && check; i++)
                if (s[i] != '0' && s[i] != '1') check = false;
            if (check) {
                for (int i = 0; i < 64; i++) DES::pre[i] = s[i] == '1'? 1: 0;
                break;
            }
            printf("Please enter valid key!\n");
            Sleep(2000);
        }
        while (true) {
            system("cls");
            printf("%s\n", kase == 1? " - - -  Encoding - - - ": " - - -  Decoding - - - ");
            printf("Please enter the file name you want to %scode: ", kase == 1? "en": "de");
            scanf("%s", s);
            if (!(f1 = fopen(s, "r"))) {
                printf("\nThere is no such file under current directory! Please enter agian.\n");
                Sleep(2000);
                continue;
            }
            char c;
            bool check = true;
            for (DES::len = 0; ~fscanf(f1, "%c", &c); DES::len++) {
                if (DES::len >= 1000 || (c != '0' && c != '1')) {
                    check = false;
                    break;
                }
                DES::text[DES::len] = c == '1'? 1: 0;
            }
            if (!check) {
                printf("\nNote: There can be less than 1000 digits of 0/1 in the input file. Please check!\n");
                Sleep(4000);
                continue;
            }
            break;
        }
        fclose(f1);
        while (true) {
            system("cls");
            printf("%s\n", kase == 1? " - - -  Encoding - - -  ": " - - -  Decoding - - -  ");
            printf("Please enter the file name you want to save %scoded text: ", kase == 1? "en": "de");
            scanf("%s", s);
            f2 = fopen(s, "w");
            break;
        }
        if (kase == 1) DES::Encode();
        else DES::Decode();
        DES::out(f2);
        fclose(f2);
        printf("Succeed!\n");
        Sleep(2000);
    }
    return 0;
}
