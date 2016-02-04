# encoding: utf-8

# Information about SteamIDs and conversion between them found here:
# https://developer.valvesoftware.com/wiki/SteamID
#
# In short:
# CommunityID32 = Z*2 + Y
# CommunityID64 = Z*2 + V + Y
# Therefore: CommunityID64 = CommunityID32 + V
# Where V is the Steam64 Identifier for the account type (0x0110000100000000
# for individuals, 0x0170000000000000 for groups)
INDIVIDUAL_ACCOUNT_TYPE_IDENTIFIER = 0x0110000100000000

def id32_from_id64(communityid64):
  return communityid64 - INDIVIDUAL_ACCOUNT_TYPE_IDENTIFIER

def id64_from_id32(communityid32):
  return communityid32 + INDIVIDUAL_ACCOUNT_TYPE_IDENTIFIER
