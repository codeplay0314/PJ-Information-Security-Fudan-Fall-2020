import random

def pow(a, n, mod):
    res = 1
    while n:
        if n&1:
            res = res * a % mod
        a = a * a % mod
        n >>= 1
    return res

def isprime(x, p):
    mid = pow(x, p - 1, p)
    if mid != 1: return False
    n = p - 1
    while n&1 == 0 and mid == 1:
        n >>= 1
        mid = pow(x, n, p)
    return mid == 1 or mid == p - 1

prime = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37]
def Miller_Rabin(x):
    for p in prime:
        if isprime(p, x) is False:
            return False
    return True

def rand64bit():
    num = 3
    for i in range(0, 61):
        num = num * 2 + random.randint(0, 1)
    num = num * 2 + 1
    return num

def generate():
    while True:
        x = rand64bit()
        if Miller_Rabin(x):
            return x


def exgcd(a, b):
    if b == 0:  
        return 1, 0, a
    else:
        x, y, gcd = exgcd(b, a % b)  
        x, y = y, (x - (a // b) * y) 
        return x, y, gcd

p = generate()
q = generate()
n = p * q
phi_n = (p - 1) * (q - 1)
d = 0
e = 0
while True:
    d = random.randint(1, phi_n - 1)
    x, y, gcd = exgcd(d, phi_n)
    if gcd == 1:
        e = (x % phi_n+ phi_n) % phi_n
        break

client = "client/"
server = "server/"
with open(client + 'n.txt', 'w') as f:
    print(n, file = f)
with open(client + 'e.txt', 'w') as f:
    print(e, file = f)
with open(client + 'd.txt', 'w') as f:
    print(d, file = f)

with open(server + 'n.txt', 'w') as f:
    print(n, file = f)
with open(server + 'd.txt', 'w') as f:
    print(d, file = f)

print("p =", p)
print("q =", q)
print("n =", n)
print("phi_n =", phi_n)
print("d =", d)
print("e =", e)