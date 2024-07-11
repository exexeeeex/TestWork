'use client';
import { IPassword } from '@/interfaces';
import { FC, useState } from 'react';
import styles from './password-card.module.scss';

const PasswordCard: FC<IPassword> = ({ name, id, createDate, value }) => {
    const [visiblePassword, setVisiblePassword] = useState(false);

    return (
        <div onClick={() => setVisiblePassword(!visiblePassword)} className={`${styles.card}`}>
            <p className={`${styles.card__name}`}>Имя: {name}</p>
            <p className={`${styles.card__value}`}>Пароль: {visiblePassword ? value : '****'}</p>
            <p className={`${styles.card__date}`}>Дата создания: {createDate}</p>
        </div>
    );
};

export default PasswordCard;
