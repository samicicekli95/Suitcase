using Locker.Enums;
using Locker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locker.Classes
{
    class SuitcaseLocker : IDigitalLock
    {
        // Class Variables
        private bool _isLocked;
        private List<char> _keyOptions;
        private List<char> _cipher;
        private List<char> _currentKeys;


        public SuitcaseLocker()
        {
            // Default Values
            _isLocked = false;
            _keyOptions = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            _cipher = new List<char>();
            _currentKeys = new List<char>();
            for (int i = 0; i < 4; i++)
            {
                _cipher.Add(_keyOptions.First());
                _currentKeys.Add(_keyOptions.First()) ;
            }
        }


        public int GetCipherLength()
        {
            if (_isLocked)
            {
                return _cipher.Count;
            }
            else
            {
                return _currentKeys.Count;
            }
        }

        public bool IsLocked()
        {
            return _isLocked;
        }

        public char Read(int circleIndex)
        {
            char value = '?';
            if (circleIndex >= 0 && circleIndex < _currentKeys.Count)
            {
                value = _currentKeys[circleIndex];
            }

            return value;
        }

        public string ReadAll()
        {
            string value = "";

            if (_currentKeys.Count > 0)
            {
                for (int i = 0; i < _currentKeys.Count; i++)
                {
                    value = value + _currentKeys[i];
                }
            }

            return value;
        }

        public bool Reset()
        {
            _currentKeys.Clear();
            for (int i = 0; i < _cipher.Count; i++)
            {
                _currentKeys.Add(_keyOptions[0]);
            }

            return true;
        }

        public bool Lock(bool garbleAfterLock)
        {
            if (!_isLocked)
            {
                _cipher.Clear();
                for (int i = 0; i < _currentKeys.Count; i++)
                {
                    _cipher.Add(_currentKeys[i]);
                }
                _isLocked = true;
                if (garbleAfterLock)
                {
                    Random r = new Random();
                    int n;
                    for (int i = 0; i < _currentKeys.Count; i++)
                    {
                        n = r.Next(0, _keyOptions.Count - 1);
                        _currentKeys[i] = _keyOptions[n];
                    }
                }
            }
            else
            {
                for (int i = 0; i < _cipher.Count; i++)
                {
                    if(_cipher[i] != _currentKeys[i])
                    {
                        _isLocked = true;
                        return _isLocked;
                    }
                }
                _isLocked = false;
            }

            return _isLocked;
        }

        public bool Turn(TurnDirection direction, int circleIndex, int step)
        {
            char _currentKey = Read(circleIndex);
            if (_currentKey == '?')
            {
                return false;
            }
            int _currentKeyIndex = _keyOptions.FindIndex(p => p.Equals(_currentKey));

            // New Index
            if (direction == TurnDirection.Forward)
            {
                _currentKeyIndex = _currentKeyIndex + step;
            }
            else
            {
                _currentKeyIndex = _currentKeyIndex - step;
            }

            while (_currentKeyIndex < 0)
            {
                _currentKeyIndex = _currentKeyIndex + _keyOptions.Count;
            }

            _currentKeyIndex = _currentKeyIndex % _keyOptions.Count;
            _currentKeys[circleIndex] = _keyOptions[_currentKeyIndex];



            return true;
        }

    }
}
