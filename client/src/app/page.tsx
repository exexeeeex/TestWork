import { PasswordPlace } from '@/components/places';
import styles from './page.module.css';

export default function Home() {
    return (
        <main className={styles.main}>
            <PasswordPlace />
        </main>
    );
}
